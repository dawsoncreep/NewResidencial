// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DroidFileSystem.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the DroidFileSystem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using GS.Mobile.Droid.Implementations;

[assembly: Xamarin.Forms.Dependency(typeof(DroidFileSystem))]

namespace GS.Mobile.Droid.Implementations
{
    using System.IO;

    using GS.Mobile.Share.FileSystem;

    /// <summary>
    /// The droid file system.
    /// </summary>
    public class DroidFileSystem : IFileSystem
    {
        /// <summary>
        /// The root.
        /// </summary>
        private readonly string root;

        /// <summary>
        /// Initializes a new instance of the <see cref="DroidFileSystem"/> class.
        /// </summary>
        public DroidFileSystem()
        {
            this.root = Path.Combine(Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath, "root");

            if (!Directory.Exists(this.root))
            {
                Directory.CreateDirectory(this.root);
            }
        }

        /// <inheritdoc />
        public string GetRootPath()
        {
            return this.root;
        }

        /// <inheritdoc />
        public string GetDatabasePath()
        {
            return Path.Combine(this.root, "GuizzySeguridad.db");
        }
    }
}