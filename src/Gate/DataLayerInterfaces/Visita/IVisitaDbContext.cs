


namespace DataLayerInterfaces
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using DataLayer;
    public interface IVisitaDbContext
    {
        DbSet<Visita> Visita { get; set; }
        DbSet<TipoVisita> TipoVisita { get; set; }
    }
}
