// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationContext.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ApplicationContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Mobile.DataLayer.Context
{
    using GS.Mobile.DataLayer.Entities;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The application context.
    /// </summary>
    public sealed class ApplicationContext : DbContext
    {
        /// <summary>
        /// The database path.
        /// </summary>
        private readonly string databasePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="databasePath">
        /// The database path.
        /// </param>
        public ApplicationContext(string databasePath)
        {
            this.databasePath = databasePath;
            this.Database.EnsureCreated();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="options">
        /// The options.
        /// </param>
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            // Constructor used for unit testing.
        }

        /// <summary>
        /// Gets or sets the token.
        /// </summary>
        public DbSet<SToken> Token { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            optionsBuilder.UseSqlite($"Filename={this.databasePath}");
        }
    }
}