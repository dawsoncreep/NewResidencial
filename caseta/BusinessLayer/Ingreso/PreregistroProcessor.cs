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

        public PreregistroProcessor(IVisitaRepositorio _visitaRepositorio)
        {
            visitaRepositorio = _visitaRepositorio;
        }
        public void GuardarCapturas(Bitmap rostro, Bitmap placaTrasera, Bitmap placaDelantera, Bitmap credencial, int id)
        {
            var urlFotos = ConfigurationManager.AppSettings["PicturePath"];
            visitaRepositorio.UpdateFotoVisita(urlFotos, id);
            System.IO.Directory.CreateDirectory(urlFotos);
            rostro.Save(urlFotos + "Rostro" + id + ".jpg");
            credencial.Save(urlFotos + "Credencial" + id + ".jpg");
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
