// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IFileSystem.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IFileSystem type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Share.FileSystem
{
    /// <summary>
    /// The FileSystem interface.
    /// </summary>
    public interface IFileSystem
    {
        /// <summary>
        /// Gets the application root folder path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetRootPath();

        /// <summary>
        /// Gets the application sqlLite database file path.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        string GetDatabasePath();
    }
}