using BusinessInterfaces;
using DataInterfaces;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class PreregistroProcessor : IIngresoSalidaProcessor
    {
        private readonly int tipoVisita = (int)TiposDeVisita.Habitual;
        private readonly IVisitaRepositorio visitaRepositorio;
        private readonly IIngresoSalidaVisitaRepositorio ingresoSalidaVisitaRepositorio;
        private string FotosPath { get; set; }

        public PreregistroProcessor(IVisitaRepositorio _visitaRepositorio, IIngresoSalidaVisitaRepositorio _ingresoSalidaVisitaRepositorio)
        {
            visitaRepositorio = _visitaRepositorio;
            ingresoSalidaVisitaRepositorio = _ingresoSalidaVisitaRepositorio;
            FotosPath = ConfigurationManager.AppSettings["PicturePath"];
        }

        public int RegistrarIngreso(string nombre, string apellidos, string placas, int idUbicacion, Bitmap rostro, Bitmap placaTrasera, Bitmap placaDelantera, Bitmap credencial, int? idVisita = null)
        {
            try
            {
                var visita = new Visita()
                {
                    Activo = true,
                    Apellidos = apellidos,
                    Nombre = nombre,
                    Placas = placas,
                    TipoVisita = new TipoVisita() { ID = tipoVisita },
                    Ubicacion = new Ubicacion() { ID = idUbicacion }
                };
                int id = visitaRepositorio.SetVisita(visita);
                System.IO.Directory.CreateDirectory(FotosPath);
                var urlRostro = FotosPath + "Rostro" + id + ".jpg";
                var urlCredencial = FotosPath + "Credencial" + id + ".jpg";
                var urlPlacaDelantera = FotosPath + "PlacaDelantera" + id + ".jpg";
                var urlPlacaTrasera = FotosPath + "PlacaTrasera" + id + ".jpg";
                rostro.Save(urlRostro);
                credencial.Save(urlCredencial);
                placaDelantera.Save(urlPlacaDelantera);
                placaTrasera.Save(urlPlacaTrasera);
                return ingresoSalidaVisitaRepositorio.SetIngreso(id, urlPlacaDelantera, urlPlacaTrasera, urlRostro, urlCredencial);
            }
            catch (Exception)
            {
                throw;
            }             
        }
        /// <summary>
        /// Registro de salida
        /// </summary>
        /// <param name="idVisita"> id de la visita de la cual se va a registrar la visita</param>
        /// <param name="placa"> foto de la placa que se registrara en la salida</param>
        /// <returns>regresa el numero de registros que se ingresaron a la base de datos</returns>
        public int RegistrarSalida(int idVisita, Bitmap placa)
        {
            try
            {
                System.IO.Directory.CreateDirectory(FotosPath);
                var urlSalida = FotosPath + DateTime.Now.ToString("ddMMyy") + "SalidaPlaca" + idVisita + ".jpg";
                placa.Save(urlSalida);
                int registros = ingresoSalidaVisitaRepositorio.SetSalida(idVisita, urlSalida);
                return registros;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
