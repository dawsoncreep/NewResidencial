// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the IRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Authentication.DataLayer.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
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
        /// Finds asynchronously all <see cref="TEntity"/>  elements that satisfies a specified condition.
        /// </summary>
        /// <param name="predicate">
        /// Search expression.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
    }
}