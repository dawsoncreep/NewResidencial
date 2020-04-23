// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the HomeController type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Controllers
{
    using System.Web.Mvc;

    /// <summary>
    /// The home controller.
    /// </summary>
    [HandleError]
    public class HomeController : Controller
    {
        /// <summary>
        /// Represents the API root view.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Index()
        {
            this.ViewBag.Title = $"{this.GetType().Name.Replace("Controller", string.Empty)}";
            return this.RedirectToAction("index", "Help");
        }
    }
}
