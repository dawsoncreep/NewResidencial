using BusinessInterfaces;
using DataInterfaces;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class VisitaProcessor : IVisitaProcessor
    {
        private readonly ITipoVisitaRepositorio TipoVisitaRepositorio;
        private IIngresoProcessor ingresoProcessor;
        public VisitaProcessor(ITipoVisitaRepositorio _tipovisitaRepositorio)
        {
            TipoVisitaRepositorio = _tipovisitaRepositorio;
        }

        public void RegistrarVisita(Bitmap rostro, Bitmap placaTrasera, Bitmap placaDelantera, Bitmap credencial, int tipoVisita, 
            string nombre, string apellidos, string descripcion, string placas, int ubicacion)
        {
            ingresoProcessor = FactoriaNegocio.Instancia.CreateIngresoProcessor(tipoVisita);            
            int id = ingresoProcessor.RegistrarIngreso(nombre, apellidos, placas, ubicacion);
            ingresoProcessor.GuardarCapturas(rostro, placaTrasera, placaDelantera, credencial, id);
        }

        public IEnumerable<TipoVisita> TiposDeVisita()
        {
            IEnumerable<TipoVisita> tiposVisita = TipoVisitaRepositorio.GetTiposVisita();
            return tiposVisita;
        }
    }
}
