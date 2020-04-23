﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FilterConfig.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the FilterConfig type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity
{
    using System.Web.Mvc;

    /// <summary>
    /// The filter config.
    /// </summary>
    public class FilterConfig
    {
        /// <summary>
        /// Register application global filters.
        /// </summary>
        /// <param name="filters">
        /// The filters.
        /// </param>
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
