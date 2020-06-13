// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IUserProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.BusinessLayer.Interfaces
{
    using System.Threading.Tasks;

    /// <summary>
    /// The UserProcessor interface.
    /// </summary>
    public interface IUserProcessor
    {
        /// <summary>
        /// Authorizes a user into system and returns the proper JWT.
        /// </summary>
        /// <param name="userName">
        /// The user Name.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<string> Login(string userName, string password);
    }
}