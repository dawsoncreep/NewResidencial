// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Authorize.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the Authorize type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Attributes
{
    using System;

    /// <summary>
    /// The viewmodel(page) is private and require a valid session validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
    public class Authorize : Attribute
    {
        /// <summary>
        /// The roles.
        /// </summary>
        private string roles;

        /// <summary>
        /// Initializes a new instance of the <see cref="Authorize"/> class.
        /// The viewmodel only needs a valid user token.
        /// </summary>
        public Authorize()
        {
            // No role based authorization.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Authorize"/> class.
        /// The viewmodel only needs a valid user token and a role base authorization.
        /// </summary>
        /// <param name="roles">
        /// The roles.
        /// </param>
        public Authorize(string roles)
        {
            this.roles = roles;
        }
    }
}