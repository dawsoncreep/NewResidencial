// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SwaggerConfig.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the SwaggerConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Web.Http;

using GuizzySeguridad.Api;

using Swashbuckle.Application;

using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace GuizzySeguridad.Api
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

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

                        c.SingleApiVersion("v1", "Guizzy Seguridad RESTful API")
                            .Description("Guizzy Seguridad Web API").Contact(
                                r => r.Url("https://github.com/dawsoncreep/").Name("Jaime Tlatecali Castorena Díaz"));
                        c.IncludeXmlComments(commentsFile);
                    }).EnableSwaggerUi(
                c =>
                    {
                        c.DocumentTitle("API Documentation");
                        c.DisableValidator();
                    });
        }
    }
}