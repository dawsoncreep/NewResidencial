// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationContext.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ApplicationContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GS.Api.DataLayer.Repositories
{
    using GS.Api.OperationalManagement.Interfaces;
    using GS.Api.Types.Models.Persistence;

    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// The application context.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// The application data manager.
        /// </summary>
        private readonly IDataManager dataManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationContext"/> class.
        /// </summary>
        /// <param name="dataManager">
        /// The data Manager.
        /// </param>
        public ApplicationContext(IDataManager dataManager)
        {
            this.dataManager = dataManager;
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
        /// Gets or sets the <see cref="SUser"/> data base entity.
        /// </summary>
        public virtual DbSet<SUser> User { get; set; }

        /// <summary>
        /// Gets or sets the rol.
        /// </summary>
        public virtual DbSet<SRol> Rol { get; set; }

        /// <summary>
        /// Gets or sets the permission.
        /// </summary>
        public virtual DbSet<SPermission> Permission { get; set; }

        /// <summary>
        /// Gets or sets the user rol.
        /// </summary>
        public virtual DbSet<SUserRol> UserRol { get; set; }

        /// <summary>
        /// Gets or sets the rol permission.
        /// </summary>
        public virtual DbSet<SRolPermission> RolPermission { get; set; }

        /// <summary>
        /// Gets or sets the User location
        /// </summary>
        public virtual DbSet<SUserLocation> UserLocation { get; set; }

        public virtual DbSet<SLocation> Location { get; set; }

        /// <inheritdoc />
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured)
            {
                return;
            }

            var connectionString = this.dataManager.GetSettingsValue("SqlServer.Default");
            optionsBuilder.UseSqlServer(connectionString);
        }

        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SUserRol>().HasKey(e => new { e.IdUsuario, e.IdRol });
            modelBuilder.Entity<SRolPermission>().HasKey(e => new { e.IdRol, e.IdPermiso });
            modelBuilder.Entity<SUserLocation>().HasKey(e => new { e.IdUbicacion, e.IdUsuario });
        }
    }
}