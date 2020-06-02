using DataInterfaces;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class VisitaRepositorio : IVisitaRepositorio 
    {
        public string ConnString { get; set; }
        public VisitaRepositorio()
        {
            ConnString = ConfigurationManager.ConnectionStrings["SecureGateEntities"].ConnectionString;
        }
        public void DesactivarVisita(int id)
        {
            throw new NotImplementedException();
        }

        public Visita GetVisitaByID(int id)
        {
            Visita visita;
            using (IVisitaDbContext context = new GeneralContext(ConnString))
            {
                var v = context.Visitas.Single(f => f.IdVisita == id);
                visita = new Visita()
                {
                    Activo = v.Activo,
                    Apellidos = v.Apellidos,
                    ID = v.IdVisita,
                    Nombre = v.Nombre,
                    Placas = v.Placas,
                    TipoVisita = context.TiposVisita.Select(s => new TipoVisita()
                    {
                        Activo = s.Activo,
                        Nombre = s.Nombre,
                        ID = s.IdTipoVisita
                    }).Single(s => s.ID == v.idTipoVisita),
                    Ubicacion = context.Ubicaciones.Select(s => new Ubicacion()
                    {
                        Activo = s.Activo,
                        ID = s.idUbicacion,
                        Nombre = s.Nombre,
                        TipoUbicacion = new TipoUbicacion() { IdTipoUbicacion = s.idTipoUbicacion }
                    }).Single(s => s.ID == v.idUbicacion)
                };
            }
            return visita;
        }

        public int SetVisita(Visita v)
        {
            var visita = new SVisita()
            {
                Activo = v.Activo,
                Apellidos = v.Apellidos,
                idTipoVisita = v.TipoVisita.ID,
                idUbicacion = v.Ubicacion.ID,
                Nombre = v.Nombre,
                Placas = v.Placas
            };
            using (GeneralContext context = new GeneralContext(ConnString))
            {
                context.Visitas.Add(visita);
                context.SaveChanges();
                return visita.IdVisita;
            }
        }

        public void UpdateFotoVisita(string urlfoto, int id)
        {
            using (var context = new GeneralContext(ConnString))
            {
                var visita = context.Visitas.Where(w => w.IdVisita == id).First();
                visita.FotoUrl = urlfoto;
                context.SaveChanges();
            }
        }        

        public IEnumerable<DGVVisitaActual> GetDGVVisitasActuales(string busqueda)
        {
            IEnumerable<DGVVisitaActual> dGVVisitas;
            using (IVisitaDbContext context = new GeneralContext(ConnString))
            {
                dGVVisitas = context.IngresoSalidaVisitas.Where(w => w.fechaSalida == null)
                .Select(s => new DGVVisitaActual()
                {
                    Domicilio = context.Ubicaciones.FirstOrDefault(f => f.idUbicacion == context.Visitas.FirstOrDefault(x => x.IdVisita == s.idVisita).idUbicacion).Nombre,
                    FechaIngreso = s.fechaIngreso,
                    IdVisita = s.idVisita,
                    NombreCompleto = context.Visitas.Where(x => x.IdVisita == s.idVisita).Select(y => y.Nombre + " " + y.Apellidos).FirstOrDefault(),
                    Placas = context.Visitas.FirstOrDefault(x => x.IdVisita == s.idVisita).Placas,
                    FotoRostro = s.fotoCabina
                }).Where(w => w.Domicilio.Contains(busqueda) || w.NombreCompleto.Contains(busqueda) || w.Placas.Contains(busqueda)).ToList();
            }
            return dGVVisitas;
        }

        public IEnumerable<DGVBusqueda> GetPreRegistros(string search )
        {
            List<DGVBusqueda> busquedas = new List<DGVBusqueda>();
            using (SqlConnection connection = new SqlConnection(ConnString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SP_GetPreRegistros", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter sqlParameter = new SqlParameter("@search", search);
                command.Parameters.Add(sqlParameter);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    busquedas.Add(new DGVBusqueda() {
                        Direccion = reader["Direccion"].ToString(),
                        IdVisita = Convert.ToInt32(reader["idVisita"]),
                        Nombre = reader["Nombre"].ToString(),
                        Placas = reader["placas"].ToString(),
                        TipoDeVisita = reader["TipoDeVisita"].ToString()
                    });
                }
                connection.Close();
            }
            return busquedas;
        }

        public IEnumerable<Visita> GetVisitasByType(TiposDeVisita tipoDeVisita)
        {
            IEnumerable<Visita> visitas;
            using (IVisitaDbContext context = new GeneralContext(ConnString))
            {
                visitas = context.Visitas.Where(w => w.idTipoVisita == (int)tipoDeVisita).Select(s => 
                new Visita()
                {
                    Activo = s.Activo,
                    Apellidos = s.Apellidos,
                    ID = s.IdVisita,
                    Nombre = s.Nombre,
                    Placas = s.Placas,
                    TipoVisita = new TipoVisita() { ID = s.idTipoVisita, Nombre = context.TiposVisita.FirstOrDefault(f => f.IdTipoVisita == s.idTipoVisita).Nombre },
                    Ubicacion = context.Ubicaciones.Select(x => new Ubicacion() { ID = x.idUbicacion }).FirstOrDefault(f => f.ID == s.idUbicacion),
                    QR = s.QR
                }).ToList();
            }
            return visitas;
        }

        public int SetSalida(int idVisita)
        {
            using (var context = new GeneralContext(ConnString))
            {
                var _visita = context.Visitas.FirstOrDefault(f => f.IdVisita == idVisita);
                context.IngresoSalidaVisitas.FirstOrDefault(f => f.idVisita == _visita.IdVisita && f.fechaSalida == null).fechaSalida = DateTime.Now;
                return context.SaveChanges();
            }
        }
    }
}
