// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainActivity.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the MainActivity type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Droid
{
    using System.Diagnostics.CodeAnalysis;

    using Android.App;
    using Android.Content.PM;
    using Android.OS;
    using Android.Runtime;

    /// <summary>
    /// The main activity.
    /// </summary>
    [Activity(Label = "Guizzy Seguridad", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        /// <summary>
        /// The permissions.
        /// </summary>
        private readonly string[] allowedPermissions =
            {
                Android.Manifest.Permission.Internet,
                Android.Manifest.Permission.ReadExternalStorage,
                Android.Manifest.Permission.WriteExternalStorage
            };

        /// <summary>
        /// Gets the application instance.
        /// </summary>
        public static MainActivity ApplicationInstance { get; private set; }
        
        /// <inheritdoc />
        [SuppressMessage("StyleCop.CSharp.ReadabilityRules", "SA1126:PrefixCallsCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            ApplicationInstance = this;

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);

            this.RequestPermissions(this.allowedPermissions, 0);
            this.LoadApplication(new App());
        }

        /// <inheritdoc />
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}