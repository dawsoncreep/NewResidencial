// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TextSample.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   This represents a preformatted text sample on the help page. There's a display template named TextSample associated with this class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Areas.HelpPage.SampleGeneration
{
    using System;

    /// <summary>
    /// This represents a preformatted text sample on the help page. There's a display template named TextSample associated with this class.
    /// </summary>
    public class TextSample
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TextSample"/> class.
        /// </summary>
        /// <param name="text">
        /// The text.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when input text is null or empty
        /// </exception>
        public TextSample(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            this.Text = text;
        }

        /// <summary>
        /// Gets the text.
        /// </summary>
        public string Text { get; }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is TextSample other && this.Text == other.Text;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return this.Text.GetHashCode();
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.Text;
        }
    }
}