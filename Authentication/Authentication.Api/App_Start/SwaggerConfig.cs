// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwaggerConfig.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SwaggerConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;

using Authentication.Api;

using Swashbuckle.Application;

using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace Authentication.Api
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Reflection;

    /// <summary>
    /// The swagger config.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class SwaggerConfig
    {
        /// <summary>
        /// The register.
        /// </summary>
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration.EnableSwagger(
                c =>
                    {
                        var baseDirectory = AppDomain.CurrentDomain.BaseDirectory + @"\bin";
                        var commentsFile = Path.Combine(baseDirectory, "XmlDocument.xml");

                        c.SingleApiVersion("v1", "Authentication Web Api")
                            .Description("Residential Authentication Web API").Contact(
                                r => r.Url("https://github.com/dawsoncreep/").Name("Jaime Tlatecali Castorena Díaz"));
                        c.IncludeXmlComments(commentsFile);
                    }).EnableSwaggerUi(
                c =>
                    {
                        c.DocumentTitle("Authentication Documentation");
                        c.DisableValidator();
                    });
        }
    }
}