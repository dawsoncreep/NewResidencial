// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ServiceCallResult.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ServiceCallResult type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.Types.Network
{
    /// <summary>
    /// The REST service call result.
    /// </summary>
    /// <typeparam name="TResult">
    /// The response result.
    /// </typeparam>
    public class ServiceCallResult<TResult>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceCallResult{TResult}"/> class.
        /// </summary>
        /// <param name="statusCode">
        /// The status code.
        /// </param>
        /// <param name="result">
        /// The result.
        /// </param>
        /// <param name="error">
        /// The error.
        /// </param>
        public ServiceCallResult(int statusCode, TResult result, string error = null)
        {
            this.StatusCode = statusCode;
            this.Result = result;
            this.Error = error;
        }

        /// <summary>
        /// Gets the status code.
        /// </summary>
        public int StatusCode { get; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        public TResult Result { get; }

        /// <summary>
        /// Gets the error.
        /// </summary>
        public string Error { get; }
    }
}