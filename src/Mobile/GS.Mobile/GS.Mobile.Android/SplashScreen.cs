// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SplashScreen.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   The splash screen.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Droid
{
    using Android.App;
    using Android.OS;

    /// <summary>
    /// The splash screen.
    /// </summary>
    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {
        /// <summary>
        /// The on create.
        /// </summary>
        /// <param name="savedInstanceState">
        /// The saved instance state.
        /// </param>
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            this.StartActivity(typeof(MainActivity));
        }
    }
}