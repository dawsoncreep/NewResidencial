// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HelpController.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   The controller that will handle requests for the help page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Areas.HelpPage.Controllers
{
    using System.Web.Http;
    using System.Web.Mvc;

    using Residential.Identity.Areas.HelpPage.ModelDescriptions;

    /// <summary>
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class HelpController : Controller
    {
        /// <summary>
        /// The error view name.
        /// </summary>
        private const string ErrorViewName = "Error";

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpController"/> class.
        /// </summary>
        public HelpController() : this(GlobalConfiguration.Configuration)
        {
            this.ViewBag.Title = $"{this.GetType().Name.Replace("Controller", string.Empty)}";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HelpController"/> class.
        /// </summary>
        /// <param name="config">
        /// The config.
        /// </param>
        public HelpController(HttpConfiguration config)
        {
            this.Configuration = config;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        public HttpConfiguration Configuration { get; }

        #region Public Actions

        /// <summary>
        /// Represents the API root view.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            this.ViewBag.DocumentationProvider = this.Configuration.Services.GetDocumentationProvider();
            return this.View(this.Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        /// <summary>
        /// Represents the API detail view.
        /// </summary>
        /// <param name="apiId">
        /// The api id.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Api(string apiId)
        {
            if (string.IsNullOrEmpty(apiId))
            {
                return this.View(ErrorViewName);
            }

            var apiModel = this.Configuration.GetHelpPageApiModel(apiId);
            return apiModel != null ? this.View(apiModel) : this.View(ErrorViewName);
        }

        /// <summary>
        /// The resource model.
        /// </summary>
        /// <param name="modelName">
        /// The model name.
        /// </param>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult ResourceModel(string modelName)
        {
            if (string.IsNullOrEmpty(modelName))
            {
                return this.View(ErrorViewName);
            }

            var modelDescriptionGenerator = this.Configuration.GetModelDescriptionGenerator();
            ModelDescription modelDescription;
            return modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription) ? this.View(modelDescription) : this.View(ErrorViewName);
        }
        #endregion
    }
}