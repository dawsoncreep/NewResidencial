// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaseRepository.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the BaseRepository type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.DataLayer.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;

    using GS.Api.DataLayer.Interfaces;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The base repository.
    /// </summary>
    /// <typeparam name="TEntity">
    /// Specific object to work with.
    /// </typeparam>
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// The entities.
        /// </summary>
        private readonly DbSet<TEntity> currentEntity;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{TEntity}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public BaseRepository(DbContext context)
        {
            this.CurrentContext = context;
            this.currentEntity = this.CurrentContext.Set<TEntity>();
        }

        /// <summary>
        /// Gets the current context being used.
        /// </summary>
        /// <returns>
        /// The <see cref="DbContext"/>.
        /// </returns>
        protected DbContext CurrentContext { get; }

        /// <inheritdoc />
        public async Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await this.currentEntity.Where(predicate).ToListAsync();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await this.currentEntity.AddAsync(entity);
        }
    }
}