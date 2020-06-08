// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Authorization.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the Authorization type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Attributes
{
    using System;

    /// <summary>
    /// The viewmodel(page) is private and require a valid session validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Property, Inherited = false)]
    public class Authorization : Attribute
    {
        /// <summary>
        /// The roles.
        /// </summary>
        private string roles;


        /// <summary>
        /// Initializes a new instance of the <see cref="Authorization"/> class.
        /// The viewmodel only needs a valid user token.
        /// </summary>
        public Authorization()
        {
            // No role based authorization.
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Authorization"/> class.
        /// The viewmodel only needs a valid user token and a role base authorization.
        /// </summary>
        /// <param name="roles">
        /// The roles.
        /// </param>
        public Authorization(string roles)
        {
            // Role based authorization.
            this.roles = roles;
        }
    }
}