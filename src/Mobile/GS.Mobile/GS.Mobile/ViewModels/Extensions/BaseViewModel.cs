// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseViewModel.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BaseViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.ViewModels.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using GS.Mobile.ViewModels.Attributes;

    using Xamarin.Forms;

    /// <inheritdoc />
    /// <summary>
    /// The base view model.
    /// </summary>
    public abstract class BaseViewModel : IViewModel
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        protected BaseViewModel()
        {
            // TODO: Manage dependencies thorough constructor.
            this.ValidateAuthorizationRules();
        }

#pragma warning disable 067

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 067

        /// <inheritdoc />
        public bool IsBusy { get; set; }

        /// <inheritdoc />
        public string PageTitle { get; set; }

        /// <inheritdoc />
        public virtual ICommand OnLoadCommand => new Command(async () =>
            {
                // TODO
                await Task.CompletedTask;
            });

        /// <inheritdoc />
        public virtual ICommand OnCloseCommand => new Command(async () => await Task.CompletedTask);

        /// <inheritdoc />
        public async Task CleanUi()
        {
            await Task.CompletedTask;
        }

        #region private Methods

        /// <summary>
        /// Gets the viewmodel custom attributes.
        /// </summary>
        /// <returns>
        /// The <see cref="List{CustomAttributeData}"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// Thrown when the viewmodel does not have the <see cref="Authorization"/> attribute or the <see cref="AllowAnonymous"/> attribute.
        /// </exception>
        private IEnumerable<CustomAttributeData> GetCustomAttributes()
        {
            var attributes = this.GetType().CustomAttributes.ToList();

            if (attributes == null || !attributes.Any())
            {
                throw new Exception("'AllowAnonymous' or 'Authorization' attribute is missing.");
            }

            return attributes;
        }

        /// <summary>
        /// Determines if the viewmodel is public allowed.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsAnonymousAllowed()
        {
            var attributes = this.GetCustomAttributes();
            return attributes.Any(item => item.AttributeType.Name == typeof(AllowAnonymous).Name);
        }

        /// <summary>
        /// Determines if the viewmodel needs an authorization validation.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsAuthorizationRequired()
        {
            var attributes = this.GetCustomAttributes();
            return attributes.Any(item => item.AttributeType.Name == typeof(Authorization).Name);
        }

        /// <summary>
        /// Gets allowed roles for this particular viewmodel.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GetViewModelAuthorizationRoles()
        {
            var attributes = this.GetCustomAttributes();
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
        /// The validate user roles.
        /// </summary>
        private void ValidateAuthorizationRules()
        {
            if (this.IsAnonymousAllowed())
            {
                return;
            }

            if (this.IsAuthorizationRequired())
            {
                var viewModelRoles = this.GetViewModelAuthorizationRoles();

                if (string.IsNullOrEmpty(viewModelRoles))
                {
                    // validates only user token
                }
                else
                {
                    // Validate user token and roles
                }
            }
            else
            {
                throw new Exception("'AllowAnonymous' or 'Authorization' attribute is missing.");
            }
        }
        #endregion
    }
}