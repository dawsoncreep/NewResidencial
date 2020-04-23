// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ImageSample.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   This represents an image sample on the help page. There's a display template named ImageSample associated with this class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Residential.Identity.Areas.HelpPage.SampleGeneration
{
    using System;

    /// <summary>
    /// This represents an image sample on the help page. There's a display template named ImageSample associated with this class.
    /// </summary>
    public class ImageSample
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageSample"/> class.
        /// </summary>
        /// <param name="src">The URL of an image.</param>
        public ImageSample(string src)
        {
            this.Src = src ?? throw new ArgumentNullException(nameof(src));
        }

        /// <summary>
        /// Gets the image source path.
        /// </summary>
        public string Src { get; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is ImageSample other && this.Src == other.Src;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.Src.GetHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Src;
        }
    }
}