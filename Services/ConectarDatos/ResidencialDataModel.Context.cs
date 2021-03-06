﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConectarDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ResidencialEntities : DbContext
    {
        public ResidencialEntities()
            : base("name=ResidencialEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Boletin> Boletin { get; set; }
        public virtual DbSet<Dispositivo> Dispositivo { get; set; }
        public virtual DbSet<Evento> Evento { get; set; }
        public virtual DbSet<Huella> Huella { get; set; }
        public virtual DbSet<Parametro> Parametro { get; set; }
        public virtual DbSet<Permiso> Permiso { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<Rol> Rol { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tipoUbicacion> tipoUbicacion { get; set; }
        public virtual DbSet<TipoVisita> TipoVisita { get; set; }
        public virtual DbSet<Ubicacion> Ubicacion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Vehiculo> Vehiculo { get; set; }
        public virtual DbSet<Visita> Visita { get; set; }
        public virtual DbSet<FotoEventoEntrada> FotoEventoEntrada { get; set; }
        public virtual DbSet<FotoEventoSalida> FotoEventoSalida { get; set; }
        public virtual DbSet<IngresoSalidaPersonal> IngresoSalidaPersonal { get; set; }
        public virtual DbSet<ingresoSalidaVisita> ingresoSalidaVisita { get; set; }
        public virtual DbSet<PersonalUbicacion> PersonalUbicacion { get; set; }
        public virtual DbSet<RolPermiso> RolPermiso { get; set; }
        public virtual DbSet<SolicitudAcceso> SolicitudAcceso { get; set; }
        public virtual DbSet<UsuarioRol> UsuarioRol { get; set; }
        public virtual DbSet<usuarioUbicacion> usuarioUbicacion { get; set; }
        public virtual DbSet<UsuarioVisita> UsuarioVisita { get; set; }
        public virtual DbSet<VehiculoUbicacion> VehiculoUbicacion { get; set; }
    }
}
