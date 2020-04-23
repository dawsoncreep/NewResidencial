// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpPageConfigurationExtensions.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the HelpPageConfigurationExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Areas.HelpPage
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Web.Http;
    using System.Web.Http.Description;

    using Residential.Identity.Areas.HelpPage.ModelDescriptions;
    using Residential.Identity.Areas.HelpPage.Models;
    using Residential.Identity.Areas.HelpPage.SampleGeneration;

    /// <summary>
    /// The help page configuration extensions.
    /// </summary>
    public static class HelpPageConfigurationExtensions
    {
        /// <summary>
        /// The api model prefix.
        /// </summary>
        private const string ApiModelPrefix = "MS_HelpPageApiModel_";

        /// <summary>
        /// Gets the help page sample generator.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <returns>The help page sample generator.</returns>
        public static HelpPageSampleGenerator GetHelpPageSampleGenerator(this HttpConfiguration config)
        {
            return (HelpPageSampleGenerator)config.Properties.GetOrAdd(
                typeof(HelpPageSampleGenerator),
                k => new HelpPageSampleGenerator());
        }

        #region Private Methods

        /// <summary>
        /// Generates the api model.
        /// </summary>
        /// <param name="apiDescription">
        /// The api description.
        /// </param>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <returns>
        /// The <see cref="HelpPageApiModel"/>.
        /// </returns>
        private static HelpPageApiModel GenerateApiModel(ApiDescription apiDescription, HttpConfiguration config)
        {
            var apiModel = new HelpPageApiModel { ApiDescription = apiDescription };

            var modelGenerator = config.GetModelDescriptionGenerator();
            var sampleGenerator = config.GetHelpPageSampleGenerator();
            GenerateUriParameters(apiModel, modelGenerator);
            GenerateRequestModelDescription(apiModel, modelGenerator, sampleGenerator);
            GenerateResourceDescription(apiModel, modelGenerator);
            GenerateSamples(apiModel, sampleGenerator);

            return apiModel;
        }

        /// <summary>
        /// Generates the uri parameters.
        /// </summary>
        /// <param name="apiModel">
        /// The api model.
        /// </param>
        /// <param name="modelGenerator">
        /// The model generator.
        /// </param>
        private static void GenerateUriParameters(HelpPageApiModel apiModel, ModelDescriptionGenerator modelGenerator)
        {
            var apiDescription = apiModel.ApiDescription;
            foreach (var apiParameter in apiDescription.ParameterDescriptions)
            {
                if (apiParameter.Source != ApiParameterSource.FromUri)
                {
                    continue;
                }

                var parameterDescriptor = apiParameter.ParameterDescriptor;
                Type parameterType = null;
                ModelDescription typeDescription = null;
                ComplexTypeModelDescription complexTypeDescription = null;
                if (parameterDescriptor != null)
                {
                    parameterType = parameterDescriptor.ParameterType;
                    typeDescription = modelGenerator.GetOrCreateModelDescription(parameterType);
                    complexTypeDescription = typeDescription as ComplexTypeModelDescription;
                }

                if (complexTypeDescription != null && !IsBindableWithTypeConverter(parameterType))
                {
                    foreach (var uriParameter in complexTypeDescription.Properties)
                    {
                        apiModel.UriParameters.Add(uriParameter);
                    }
                }
                else if (parameterDescriptor != null)
                {
                    var uriParameter = AddParameterDescription(apiModel, apiParameter, typeDescription);

                    if (!parameterDescriptor.IsOptional)
                    {
                        uriParameter.Annotations.Add(new ParameterAnnotation { Documentation = "Required" });
                    }

                    var defaultValue = parameterDescriptor.DefaultValue;
                    if (defaultValue != null)
                    {
                        uriParameter.Annotations.Add(new ParameterAnnotation { Documentation = "Default value is " + Convert.ToString(defaultValue, CultureInfo.InvariantCulture) });
                    }
                }
                else
                {
                    // If parameterDescriptor is null, this is an undeclared route parameter which only occurs
                    // when source is FromUri. Ignored in request model and among resource parameters but listed
                    // as a simple string here.
                    var modelDescription = modelGenerator.GetOrCreateModelDescription(typeof(string));
                    AddParameterDescription(apiModel, apiParameter, modelDescription);
                }
            }
        }

        /// <summary>
        /// Gets a value indicating if input <see cref="Type"/> object is bindable with type converter.
        /// </summary>
        /// <param name="parameterType">
        /// The parameter type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool IsBindableWithTypeConverter(Type parameterType)
        {
            return parameterType != null && TypeDescriptor.GetConverter(parameterType).CanConvertFrom(typeof(string));
        }

        /// <summary>
        /// Adds a parameter description into documentation.
        /// </summary>
        /// <param name="apiModel">
        /// The api model.
        /// </param>
        /// <param name="apiParameter">
        /// The api parameter.
        /// </param>
        /// <param name="typeDescription">
        /// The type description.
        /// </param>
        /// <returns>
        /// The <see cref="ParameterDescription"/>.
        /// </returns>
        private static ParameterDescription AddParameterDescription(HelpPageApiModel apiModel, ApiParameterDescription apiParameter, ModelDescription typeDescription)
        {
            var parameterDescription = new ParameterDescription
            {
                Name = apiParameter.Name,
                Documentation = apiParameter.Documentation,
                TypeDescription = typeDescription
            };

            apiModel.UriParameters.Add(parameterDescription);
            return parameterDescription;
        }

        /// <summary>
        /// Generates the request model description.
        /// </summary>
        /// <param name="apiModel">
        /// The api model.
        /// </param>
        /// <param name="modelGenerator">
        /// The model generator.
        /// </param>
        /// <param name="sampleGenerator">
        /// The sample generator.
        /// </param>
        private static void GenerateRequestModelDescription(HelpPageApiModel apiModel, ModelDescriptionGenerator modelGenerator, HelpPageSampleGenerator sampleGenerator)
        {
            var apiDescription = apiModel.ApiDescription;
            foreach (var apiParameter in apiDescription.ParameterDescriptions)
            {
                if (apiParameter.Source == ApiParameterSource.FromBody)
                {
                    var parameterType = apiParameter.ParameterDescriptor.ParameterType;
                    apiModel.RequestModelDescription = modelGenerator.GetOrCreateModelDescription(parameterType);
                    apiModel.RequestDocumentation = apiParameter.Documentation;
                }
                else if (apiParameter.ParameterDescriptor != null &&
                    apiParameter.ParameterDescriptor.ParameterType == typeof(HttpRequestMessage))
                {
                    var parameterType = sampleGenerator.ResolveHttpRequestMessageType(apiDescription);

                    if (parameterType != null)
                    {
                        apiModel.RequestModelDescription = modelGenerator.GetOrCreateModelDescription(parameterType);
                    }
                }
            }
        }

        /// <summary>
        /// Generates the resource description.
        /// </summary>
        /// <param name="apiModel">
        /// The api model.
        /// </param>
        /// <param name="modelGenerator">
        /// The model generator.
        /// </param>
        private static void GenerateResourceDescription(HelpPageApiModel apiModel, ModelDescriptionGenerator modelGenerator)
        {
            var response = apiModel.ApiDescription.ResponseDescription;
            var responseType = response.ResponseType ?? response.DeclaredType;
            if (responseType != null && responseType != typeof(void))
            {
                apiModel.ResourceDescription = modelGenerator.GetOrCreateModelDescription(responseType);
            }
        }

        /// <summary>
        /// Generates the documentation samples.
        /// </summary>
        /// <param name="apiModel">
        /// The api model.
        /// </param>
        /// <param name="sampleGenerator">
        /// The sample generator.
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "The exception is recorded as ErrorMessages.")]
        private static void GenerateSamples(HelpPageApiModel apiModel, HelpPageSampleGenerator sampleGenerator)
        {
            try
            {
                foreach (var item in sampleGenerator.GetSampleRequests(apiModel.ApiDescription))
                {
                    apiModel.SampleRequests.Add(item.Key, item.Value);
                    LogInvalidSampleAsError(apiModel, item.Value);
                }

                foreach (var item in sampleGenerator.GetSampleResponses(apiModel.ApiDescription))
                {
                    apiModel.SampleResponses.Add(item.Key, item.Value);
                    LogInvalidSampleAsError(apiModel, item.Value);
                }
            }
            catch (Exception e)
            {
                apiModel.ErrorMessages.Add(string.Format(CultureInfo.CurrentCulture, "An exception has occurred while generating the sample. Exception message: {0}", HelpPageSampleGenerator.UnwrapException(e).Message));
            }
        }

        /// <summary>
        /// Gets a value indicating if resource parameter was successfully retrieve from a <see cref="ApiDescription"/> object using the current <see cref="HttpConfiguration"/>.
        /// </summary>
        /// <param name="apiDescription">
        /// The api description.
        /// </param>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <param name="parameterDescription">
        /// The parameter description.
        /// </param>
        /// <param name="resourceType">
        /// The resource type.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private static bool TryGetResourceParameter(ApiDescription apiDescription, HttpConfiguration config, out ApiParameterDescription parameterDescription, out Type resourceType)
        {
            parameterDescription = apiDescription.ParameterDescriptions.FirstOrDefault(
                p => p.Source == ApiParameterSource.FromBody ||
                    (p.ParameterDescriptor != null && p.ParameterDescriptor.ParameterType == typeof(HttpRequestMessage)));

            if (parameterDescription == null)
            {
                resourceType = null;
                return false;
            }

            resourceType = parameterDescription.ParameterDescriptor.ParameterType;

            if (resourceType == typeof(HttpRequestMessage))
            {
                var sampleGenerator = config.GetHelpPageSampleGenerator();
                resourceType = sampleGenerator.ResolveHttpRequestMessageType(apiDescription);
            }

            if (resourceType != null)
            {
                return true;
            }

            parameterDescription = null;
            return false;
        }

        /// <summary>
        /// Initialize the model description generator.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        /// <returns>
        /// The <see cref="ModelDescriptionGenerator"/>.
        /// </returns>
        private static ModelDescriptionGenerator InitializeModelDescriptionGenerator(HttpConfiguration config)
        {
            var modelGenerator = new ModelDescriptionGenerator(config);
            var apis = config.Services.GetApiExplorer().ApiDescriptions;
            foreach (var api in apis)
            {
                if (TryGetResourceParameter(api, config, out _, out var parameterType))
                {
                    modelGenerator.GetOrCreateModelDescription(parameterType);
                }
            }

            return modelGenerator;
        }

        /// <summary>
        /// Logs an invalid sample as error.
        /// </summary>
        /// <param name="apiModel">
        /// The api model.
        /// </param>
        /// <param name="sample">
        /// The sample.
        /// </param>
        private static void LogInvalidSampleAsError(HelpPageApiModel apiModel, object sample)
        {
            if (sample is InvalidSample invalidSample)
            {
                apiModel.ErrorMessages.Add(invalidSample.ErrorMessage);
            }
        }
        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the documentation provider for help page.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="documentationProvider">The documentation provider.</param>
        public static void SetDocumentationProvider(this HttpConfiguration config, IDocumentationProvider documentationProvider)
        {
            config.Services.Replace(typeof(IDocumentationProvider), documentationProvider);
        }

        /// <summary>
        /// Sets the sample directly for all actions with the specified media type.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sample">The sample.</param>
        /// <param name="mediaType">The media type.</param>
        public static void SetSampleForMediaType(this HttpConfiguration config, object sample, MediaTypeHeaderValue mediaType)
        {
            config.GetHelpPageSampleGenerator().ActionSamples.Add(new HelpPageSampleKey(mediaType), sample);
        }

        /// <summary>
        /// Gets the model description generator.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>The <see cref="ModelDescriptionGenerator"/></returns>
        public static ModelDescriptionGenerator GetModelDescriptionGenerator(this HttpConfiguration config)
        {
            return (ModelDescriptionGenerator)config.Properties.GetOrAdd(
                typeof(ModelDescriptionGenerator),
                k => InitializeModelDescriptionGenerator(config));
        }

        /// <summary>
        /// Gets the model that represents an API displayed on the help page. The model is initialized on the first call and cached for subsequent calls.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="apiDescriptionId">The <see cref="ApiDescription"/> ID.</param>
        /// <returns>
        /// An <see cref="HelpPageApiModel"/>
        /// </returns>
        public static HelpPageApiModel GetHelpPageApiModel(this HttpConfiguration config, string apiDescriptionId)
        {
            var modelId = ApiModelPrefix + apiDescriptionId;
            if (config.Properties.TryGetValue(modelId, out var model))
            {
                return (HelpPageApiModel)model;
            }

            var apiDescriptions = config.Services.GetApiExplorer().ApiDescriptions;
            var apiDescription = apiDescriptions.FirstOrDefault(api => string.Equals(api.GetFriendlyId(), apiDescriptionId, StringComparison.OrdinalIgnoreCase));

            if (apiDescription == null)
            {
                return null;
            }

            model = GenerateApiModel(apiDescription, config);
            config.Properties.TryAdd(modelId, model);

            return (HelpPageApiModel)model;
        }
        #endregion   
    }
}
