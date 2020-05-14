// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApplicationContext.cs" company="Dawsoncreep GitHub Repository(https://github.com/dawsoncreep/).">
//   COPYRIGHT 2020 © Dawsoncreep. All rights reserved.
// </copyright>
// <summary>
//   Defines the ApplicationContext type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace GuizzySeguridad.Common.Server.DataLayer.Repositories
{
    using GuizzySeguridad.Common.OperationalManagement.Interfaces;
    using GuizzySeguridad.Common.Types.Models.Persistence;

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
        /// Gets or sets the role.
        /// </summary>
        public virtual DbSet<SRol> Role { get; set; }

        /// <summary>
        /// Gets or sets the permission.
        /// </summary>
        public virtual DbSet<SPermission> Permission { get; set; }

        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        public virtual DbSet<SUserRole> UserRole { get; set; }

        /// <summary>
        /// Gets or sets the role permission.
        /// </summary>
        public virtual DbSet<SRolePermission> RolePermission { get; set; }

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
            modelBuilder.Entity<SUserRole>().HasKey(e => new { e.IdUsuario, e.IdRol });
            modelBuilder.Entity<SRolePermission>().HasKey(e => new { e.IdRol, e.IdPermiso });
        }
    }
}