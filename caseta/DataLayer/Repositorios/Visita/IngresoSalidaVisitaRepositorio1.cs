using DataInterfaces;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class IngresoSalidaVisitaRepositorio : IIngresoSalidaVisitaRepositorio
    {
        public string ConnString { get; set; }
        public IngresoSalidaVisitaRepositorio()
        {
            ConnString = ConfigurationManager.ConnectionStrings["SecureGateEntities"].ConnectionString;
        }
        public void SetIngreso(int id, string placaDelantera, string placaTrasera, string cabina, string identificacion)
        {
            using (var context = new GeneralContext(ConnString))
            {
                var ingreso = new SIngresoSalidaVisita()
                {
                    idVisita = id,
                    fechaIngreso = DateTime.Now,
                    fotoCabina = cabina,
                    fotoIdentificacion = identificacion,
                    fotoPlacaDelantera = placaDelantera,
                    fotoPlacaTrasera = placaDelantera
                };
                context.IngresoSalidaVisitas.Add(ingreso);
                context.SaveChangesAsync();
            }            
        }

        public void SetSalida(int idVisita, string fotoSalida)
        {
            using (var context = new GeneralContext(ConnString))
            {
                var ingreso = context.IngresoSalidaVisitas.Where(w => w.fechaSalida == null && w.idVisita == idVisita).FirstOrDefault();
                ingreso.fotoSalidaUrl = fotoSalida;
                ingreso.fechaSalida = DateTime.Now;
                context.SaveChangesAsync();
            }
        }
    }
}
