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
        private readonly IVisitaRepositorio visitaRepositorio;
        private IIngresoProcessor ingresoProcessor; // interfaz que implementa la funcion de la visita al ingresar dependiento el tipo
        public VisitaProcessor(ITipoVisitaRepositorio _tipovisitaRepositorio, IVisitaRepositorio _visitaRepositorio)
        {
            TipoVisitaRepositorio = _tipovisitaRepositorio;
            visitaRepositorio = _visitaRepositorio;
        }

        public IEnumerable<DGVVisitaActual> GetVisitasActuales()
        {
            var dgvVisitas = visitaRepositorio.GetDGVVisitasActuales();
            return dgvVisitas;
        }

        public IEnumerable<DGVBusqueda> GetDGVBusquedas(string search = "")
        {
            var dgvBusqueda = visitaRepositorio.GetPreRegistros(search);
            return dgvBusqueda;
        }

        public int RegistrarVisita(Bitmap rostro, Bitmap placaTrasera, Bitmap placaDelantera, Bitmap credencial, int tipoVisita, 
            string nombre, string apellidos, string descripcion, string placas, int ubicacion, int? idVisita = null)
        {
            ingresoProcessor = FactoriaNegocio.Instancia.CreateIngresoProcessor(tipoVisita);   // se crea la instancia del ingreso segun el tipo de visita
            if (idVisita == null)
            {
                int id = ingresoProcessor.RegistrarIngreso(nombre, apellidos, placas, ubicacion);
                return ingresoProcessor.GuardarCapturas(rostro, placaTrasera, placaDelantera, credencial, id);
            }
            else
            {
                return ingresoProcessor.GuardarCapturas(rostro, placaTrasera, placaDelantera, credencial, (int)idVisita);
            }
        }

        public IEnumerable<TipoVisita> TiposDeVisita()
        {
            IEnumerable<TipoVisita> tiposVisita = TipoVisitaRepositorio.GetTiposVisita();
            return tiposVisita;
        }

        public Visita GetVisitaByID(int id)
        {
            return visitaRepositorio.GetVisitaByID(id);
        }

        public int GetNumVisitas(TiposDeVisita tipoVisita)
        {
            int num = visitaRepositorio.GetVisitasByType(tipoVisita).Count();
            return num;
        }
    }
}
