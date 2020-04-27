using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataInterfaces;
using SecureGateTypes;

namespace DataLayer
{
    public class UbicacionRepositorio : IUbicacionesRepositorio
    {
        string conString = ConfigurationManager.ConnectionStrings["SecureGateEntities"].ConnectionString;
        public IEnumerable<Ubicacion> GetAllUbicacions()
        {
            IEnumerable<Ubicacion> ubicaciones;
            using (IUbicacionesDBContext context = new GeneralContext(conString))
            {
                ubicaciones = context.Ubicaciones.Select(s => new Ubicacion()
                {
                    Activo = s.Activo,
                    ID = s.idUbicacion,
                    Nombre = s.Nombre,
                    TipoUbicacion = context.TiposUbicacion.Where(f => f.IdTipoUbicacion == s.idTipoUbicacion).Select(x => new TipoUbicacion()
                    {
                        IdTipoUbicacion = x.IdTipoUbicacion,
                        Nombre = x.Nombre
                    }).FirstOrDefault()
                }).ToList();
            }
            return ubicaciones;
        }

        public Ubicacion GetUbicacionByID(int id)
        {
            using (IUbicacionesDBContext context = new GeneralContext(conString))
            {
                return context.Ubicaciones.Where(f => f.idUbicacion == id).Select(s => new Ubicacion()
                {
                    Activo = s.Activo,
                    ID = s.idUbicacion,
                    Nombre = s.Nombre,
                    TipoUbicacion = context.TiposUbicacion.Where(w => w.IdTipoUbicacion == s.idTipoUbicacion).Select(x => new TipoUbicacion()
                    {
                        IdTipoUbicacion = x.IdTipoUbicacion,
                        Nombre = x.Nombre
                    }).FirstOrDefault()
                }).FirstOrDefault();
            }
        }

        public IEnumerable<Ubicacion> GetUbicacionsByType(int idType)
        {
            IEnumerable<Ubicacion> ubicaciones;
            using (IUbicacionesDBContext context = new GeneralContext(conString))
            {
                ubicaciones = context.Ubicaciones.Where(w => w.idTipoUbicacion == idType).Select(s => new Ubicacion()
                {
                    Activo = s.Activo,
                    ID = s.idUbicacion,
                    Nombre = s.Nombre,
                    TipoUbicacion = context.TiposUbicacion.Where(f => f.IdTipoUbicacion == s.idTipoUbicacion).Select(x => new TipoUbicacion()
                    {
                        IdTipoUbicacion = x.IdTipoUbicacion,
                        Nombre = x.Nombre
                    }).FirstOrDefault()
                }).ToList();
            }
            return ubicaciones;
        }

        public IEnumerable<Ubicacion> UbicacionesValidas()
        {
            IEnumerable<Ubicacion> ubicaciones;
            using (IUbicacionesDBContext context = new GeneralContext(conString))
            {
                ubicaciones = context.Ubicaciones.Where(w => w.Activo == true).Select(s => new Ubicacion
                {
                    Activo = s.Activo,
                    ID = s.idUbicacion,
                    Nombre = s.Nombre,
                    TipoUbicacion = context.TiposUbicacion.Where(w => w.IdTipoUbicacion == s.idTipoUbicacion)
                                .Select(x => new TipoUbicacion()
                                {
                                    IdTipoUbicacion = s.idTipoUbicacion,
                                    Nombre = x.Nombre
                                }).FirstOrDefault()
                }).ToList();
            }
            return ubicaciones;
        }
    }
}
