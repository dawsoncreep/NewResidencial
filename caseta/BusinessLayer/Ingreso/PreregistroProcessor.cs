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
    public class PreregistroProcessor : IIngresoProcessor
    {
        private readonly int tipoVisita = (int)TiposDeVisita.Habitual;
        private readonly IVisitaRepositorio visitaRepositorio;
        private readonly IIngresoSalidaVisitaRepositorio ingresoSalidaVisitaRepositorio;

        public PreregistroProcessor(IVisitaRepositorio _visitaRepositorio, IIngresoSalidaVisitaRepositorio _ingresoSalidaVisitaRepositorio)
        {
            visitaRepositorio = _visitaRepositorio;
            ingresoSalidaVisitaRepositorio = _ingresoSalidaVisitaRepositorio;
        }
        public int GuardarCapturas(Bitmap rostro, Bitmap placaTrasera, Bitmap placaDelantera, Bitmap credencial, int id)
        {
            var urlFotos = ConfigurationManager.AppSettings["PicturePath"];
            System.IO.Directory.CreateDirectory(urlFotos);
            var urlRostro = urlFotos + "Rostro" + id + ".jpg";
            var urlCredencial = urlFotos + "Credencial" + id + ".jpg";
            var urlPlacaDelantera = urlFotos + "PlacaDelantera" + id + ".jpg";
            var urlPlacaTrasera = urlFotos + "PlacaTrasera" + id + ".jpg";
            rostro.Save(urlRostro);
            credencial.Save(urlCredencial);
            placaDelantera.Save(urlPlacaDelantera);
            placaTrasera.Save(urlPlacaTrasera);
            return ingresoSalidaVisitaRepositorio.SetIngreso(id,urlPlacaDelantera,urlPlacaTrasera,urlRostro,urlCredencial);
        }

        public int RegistrarIngreso(string nombre, string apellidos, string placas, int idUbicacion)
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
            return visitaRepositorio.SetVisita(visita);
        }
    }
}
