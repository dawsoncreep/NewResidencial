// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpPageApiModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 � Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   The model that represents an API displayed on the help page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Areas.HelpPage.Models
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Net.Http.Headers;
    using System.Web.Http.Description;

    using Residential.Identity.Areas.HelpPage.ModelDescriptions;

    /// <summary>
    /// The model that represents an API displayed on the help page.
    /// </summary>
    public class HelpPageApiModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HelpPageApiModel"/> class.
        /// </summary>
        public HelpPageApiModel()
        {
            this.UriParameters = new Collection<ParameterDescription>();
            this.SampleRequests = new Dictionary<MediaTypeHeaderValue, object>();
            this.SampleResponses = new Dictionary<MediaTypeHeaderValue, object>();
            this.ErrorMessages = new Collection<string>();
        }

        /// <summary>
        /// Gets or sets the <see cref="ApiDescription"/> that describes the API.
        /// </summary>
        public ApiDescription ApiDescription { get; set; }

        /// <summary>
        /// Gets the <see cref="ParameterDescription"/> collection that describes the URI parameters for the API.
        /// </summary>
        public Collection<ParameterDescription> UriParameters { get; }

        /// <summary>
        /// Gets or sets the documentation for the request.
        /// </summary>
        public string RequestDocumentation { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ModelDescription"/> that describes the request body.
        /// </summary>
        public ModelDescription RequestModelDescription { get; set; }

        /// <summary>
        /// Gets the request body parameter descriptions.
        /// </summary>
        public IList<ParameterDescription> RequestBodyParameters => GetParameterDescriptions(this.RequestModelDescription);

        /// <summary>
        /// Gets or sets the <see cref="ModelDescription"/> that describes the resource.
        /// </summary>
        public ModelDescription ResourceDescription { get; set; }

        /// <summary>
        /// Gets the resource property descriptions.
        /// </summary>
        public IList<ParameterDescription> ResourceProperties => GetParameterDescriptions(this.ResourceDescription);

        /// <summary>
        /// Gets the sample requests associated with the API.
        /// </summary>
        public IDictionary<MediaTypeHeaderValue, object> SampleRequests { get; }

        /// <summary>
        /// Gets the sample responses associated with the API.
        /// </summary>
        public IDictionary<MediaTypeHeaderValue, object> SampleResponses { get; }

        /// <summary>
        /// Gets the error messages associated with this model.
        /// </summary>
        public Collection<string> ErrorMessages { get; private set; }

        /// <summary>
        /// The get parameter descriptions.
        /// </summary>
        /// <param name="modelDescription">
        /// The model description.
        /// </param>
        /// <returns>
        /// The <see cref="IList{T}"/>.
        /// </returns>
        private static IList<ParameterDescription> GetParameterDescriptions(ModelDescription modelDescription)
        {
            if (modelDescription is ComplexTypeModelDescription complexTypeModelDescription)
            {
                return complexTypeModelDescription.Properties;
            }

            if (!(modelDescription is CollectionModelDescription collectionModelDescription))
            {
                return null;
            }

            complexTypeModelDescription = collectionModelDescription.ElementDescription as ComplexTypeModelDescription;
            return complexTypeModelDescription?.Properties;
        }
    }
}