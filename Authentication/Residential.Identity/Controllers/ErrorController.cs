// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorController.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ErrorController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The error controller.
    /// </summary>
    public class ErrorController : Controller
    {
        /// <summary>
        /// Shows a custom page When http error is 404 (Page not found).
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult NotFound()
        {
            return this.View();
        }
    }
}