// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AllowAnonymous.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the AllowAnonymous type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Attributes
{
    using System;

    /// <summary>
    /// The viewmodel(page) is public and does not require any session validation.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class AllowAnonymous : Attribute
    {
        /// <summary>
        /// The reason about this permission.
        /// </summary>
        private string reason;

        /// <summary>
        /// Initializes a new instance of the <see cref="AllowAnonymous"/> class.
        /// </summary>
        /// <param name="reason">
        /// The reason.
        /// </param>
        public AllowAnonymous(string reason)
        {
            this.reason = reason;
        }
    }
}