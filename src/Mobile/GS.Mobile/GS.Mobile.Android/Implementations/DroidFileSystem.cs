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

    using Android.App;

    using GS.Mobile.Share.FileSystem;

    /// <summary>
    /// The droid file system.
    /// </summary>
    public class DroidFileSystem : IFileSystem
    {
        /// <summary>
        /// The configuration file name.
        /// </summary>
        private const string ConfigurationFileName = "Settings.xml";

        /// <summary>
        /// The database file name.
        /// </summary>
        private const string DatabaseFileName = "GuizzySeguridad.db";

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
            
            if (!File.Exists(this.GetConfigFilePath()))
            {
                CreateSettingsFile(this.GetConfigFilePath());
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
            return Path.Combine(this.root, DatabaseFileName);
        }

        /// <inheritdoc />
        public string GetConfigFilePath()
        {
            return Path.Combine(this.root, "Config.xml");
        }

        /// <summary>
        /// Creates the settings file.
        /// </summary>
        /// <param name="path">
        /// The path.
        /// </param>
        private static void CreateSettingsFile(string path)
        {
            var assetStream = Application.Context.Assets.Open(ConfigurationFileName);

            using (var br = new BinaryReader(assetStream))
            {
                using (var bw = new BinaryWriter(new FileStream(path, FileMode.Create)))
                {
                    var buffer = new byte[2048];
                    int len;

                    while ((len = br.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        bw.Write(buffer, 0, len);
                    }
                }
            }
        }
    }
}