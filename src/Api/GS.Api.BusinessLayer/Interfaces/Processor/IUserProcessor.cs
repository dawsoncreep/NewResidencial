// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IUserProcessor.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IUserProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.BusinessLayer.Interfaces.Processor
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using GS.Api.Types.Exceptions;
    using GS.Api.Types.Models;
    using GS.Api.Types.Models.Persistence;

    /// <summary>
    /// The IUserProcessor interface.
    /// </summary>
    public interface IUserProcessor
    {
        /// <summary>
        /// Retrieves <see cref="User"/> information using the nickname(userName).
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        /// <exception cref="InvalidUserRolException">
        /// Thrown when role/permission is empty or incomplete.
        /// </exception>
        Task<User> GetUserByUserName(string userName);

        /// <summary>
        /// Retrieves <see cref="User"/> List whit role Settler
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>
        /// </returns>
        Task<IEnumerable<User>> GetListOfSettlerUser();

        ///  <summary>
        ///  Insert <see cref="User"/>
        ///  </summary>
        ///  <returns>
        ///  The <see cref="Task"/>
        ///  </returns>

        Task<int> InsertUser(User user);

        ///  <summary>
        ///  Retrieves <see cref="id"/> User by id
        ///  </summary>
        ///  <returns>
        ///  The <see cref="Task"/>
        ///  </returns>
        Task<User> FindById(int id);

        ///  <summary>
        ///  Retrieves <see cref="id"/> List of Rols
        ///  </summary>
        ///  <returns>
        ///  The <see cref="Task"/>
        ///  </returns>
        Task<IEnumerable<SRol>> GetAllRols();


    }
}