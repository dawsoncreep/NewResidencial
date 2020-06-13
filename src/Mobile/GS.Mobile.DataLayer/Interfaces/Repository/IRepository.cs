// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.DataLayer.Interfaces.Repository
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Specific object to work with.
    /// </typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Gets asynchronously a collection of <see cref="TEntity"/> elements given a specific page.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="size">
        /// The size.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IList<TEntity>> GetAllByPageAsync(int page = 1, int size = 100);

        /// <summary>
        /// Adds a new entity to local storage asynchronously.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task AddAsync(TEntity entity);

        /// <summary>
        /// The remove all.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task RemoveAll();
    }
}