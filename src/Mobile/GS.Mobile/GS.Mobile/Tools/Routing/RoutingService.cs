// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RoutingService.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the RoutingService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Tools.Routing
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Xamarin.Forms;

    /// <summary>
    /// The routing service.
    /// </summary>
    public class RoutingService : IRoutingService
    {
        /// <inheritdoc />
        public void SetMaster<TPage>()
        {
            Application.Current.MainPage = (Page)Activator.CreateInstance(typeof(TPage));
        }

        /// <inheritdoc />
        public async Task PushAsync<TPage>() where TPage : ContentPage
        {
            if (Application.Current.MainPage is MasterDetailPage rootPage)
            {
                if (rootPage.Detail.Navigation.NavigationStack.Any(item => item.GetType() == typeof(TPage)))
                {
                    return;
                }

                rootPage.IsPresented = false;
                await rootPage.Detail.Navigation.PushAsync((Page)Activator.CreateInstance(typeof(TPage)));
            }
        }

        /// <inheritdoc />
        public async Task PopAsync()
        {
            if (Application.Current.MainPage is MasterDetailPage rootPage)
            {
                rootPage.IsPresented = false;

                if (!rootPage.Detail.Navigation.NavigationStack.Any())
                {
                    return;
                }

                await rootPage.Detail.Navigation.PopAsync();
            }
        }
    }
}