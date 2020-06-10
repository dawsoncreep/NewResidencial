// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ViewModelExtensions.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ViewModelExtensions type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    using GS.Mobile.ViewModels.Attributes;

    /// <summary>
    /// The view model extensions.
    /// </summary>
    public static class ViewModelExtensions
    {
        /// <summary>
        /// Determines if the viewmodel is public allowed.
        /// </summary>
        /// <param name="viewModel">
        /// The view Model.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsAnonymousAllowed(this IViewModel viewModel)
        {
            var attributes = viewModel.GetCustomAttributes();
            return attributes.Any(item => item.AttributeType.Name == typeof(AllowAnonymous).Name);
        }

        /// <summary>
        /// Determines if the viewmodel needs an authorization validation.
        /// </summary>
        /// <param name="viewModel">
        /// The view Model.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsAuthorizationRequired(this IViewModel viewModel)
        {
            var attributes = viewModel.GetCustomAttributes();
            return attributes.Any(item => item.AttributeType.Name == typeof(Authorization).Name);
        }

        /// <summary>
        /// Gets allowed roles for this particular viewmodel.
        /// </summary>
        /// <param name="viewModel">
        /// The view Model.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string GetViewModelAuthorizationRoles(this IViewModel viewModel)
        {
            var attributes = viewModel.GetCustomAttributes();
            var authorizationAttribute = attributes.FirstOrDefault(item => item.AttributeType.Name == typeof(Authorization).Name);

            if (authorizationAttribute?.NamedArguments == null)
            {
                throw new Exception("'Authorization' attribute is missing");
            }

            return authorizationAttribute.ConstructorArguments.Any()
                       ? authorizationAttribute.ConstructorArguments[0].Value.ToString()
                       : string.Empty;
        }

        /// <summary>
        /// Gets the viewmodel custom attributes.
        /// </summary>
        /// <param name="viewModel">
        /// The view Model.
        /// </param>
        /// <returns>
        /// The <see cref="List{T}"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when the viewmodel does not have the <see cref="Authorization"/> attribute or the <see cref="AllowAnonymous"/> attribute.
        /// </exception>
        private static IEnumerable<CustomAttributeData> GetCustomAttributes(this IViewModel viewModel)
        {
            var attributes = viewModel.GetType().CustomAttributes.ToList();

            if (attributes == null || !attributes.Any())
            {
                throw new Exception("'AllowAnonymous' or 'Authorization' attribute is missing.");
            }

            return attributes;
        }
    }
}