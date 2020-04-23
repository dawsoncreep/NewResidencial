// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpPageConfig.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 � Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Use this class to customize the Help Page.
//   For example you can set a custom <see cref="System.Web.Http.Description.IDocumentationProvider" /> to supply the documentation
//   or you can provide the samples for the requests/responses.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Areas.HelpPage.App_Start
{
    using System.Diagnostics.CodeAnalysis;
    using System.Net.Http.Headers;
    using System.Web;
    using System.Web.Http;

    using Residential.Identity.Areas.HelpPage.SampleGeneration;

    /// <summary>
    /// Use this class to customize the Help Page.
    /// For example you can set a custom <see cref="System.Web.Http.Description.IDocumentationProvider"/> to supply the documentation
    /// or you can provide the samples for the requests/responses.
    /// </summary>
    public static class HelpPageConfig
    {
        /// <summary>
        /// The register.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "Residential.Identity.Areas.HelpPage.TextSample.#ctor(System.String)", Justification = "End users may choose to merge this string with existing localized resources.")]
        [SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "bsonspec", Justification = "Part of a URI.")]
        public static void Register(HttpConfiguration config)
        {
            config.SetDocumentationProvider(new XmlDocumentationProvider(HttpContext.Current.Server.MapPath("~/App_Data/XmlDocument.xml")));
            config.SetSampleForMediaType(new TextSample("Binary JSON content. See http://bsonspec.org for details."), new MediaTypeHeaderValue("application/bson"));
        }
    }
}