using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDBContext
{
    internal interface IVisitaDbContext
    {
            DbSet<SVisita> Visitas { get; set; }
            DbSet<STipoVisita> TiposVisita { get; set; }
            
    }
}
