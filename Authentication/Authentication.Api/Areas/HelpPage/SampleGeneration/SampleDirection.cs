// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SampleDirection.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Indicates whether the sample is used for request or response
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.Api.Areas.HelpPage.SampleGeneration
{
    /// <summary>
    /// Indicates whether the sample is used for request or response
    /// </summary>
    public enum SampleDirection
    {
        /// <summary>
        /// The request.
        /// </summary>
        Request = 0,

        /// <summary>
        /// The response.
        /// </summary>
        Response
    }
}