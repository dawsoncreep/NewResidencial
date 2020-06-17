using BusinessInterfaces;
using DataInterfaces;
using ResidencialEnums;
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
        private IIngresoSalidaProcessor ingresoSalidaProcessor; // interfaz que implementa la funcion de la visita al ingresar dependiento el tipo
        private readonly IIngresoSalidaVisitaRepositorio ingresoSalidaVisitaRepositorio; // implementacion de los metodos para recuperar path de las fotos guardadas
        public VisitaProcessor(ITipoVisitaRepositorio _tipovisitaRepositorio, IVisitaRepositorio _visitaRepositorio, IIngresoSalidaVisitaRepositorio _ingresoSalidaVisitaRepositorio)
        {
            TipoVisitaRepositorio = _tipovisitaRepositorio;
            visitaRepositorio = _visitaRepositorio;
            ingresoSalidaVisitaRepositorio = _ingresoSalidaVisitaRepositorio;
        }

        public IEnumerable<DGVVisitaActual> GetVisitasActuales(string search = "")
        {
            var dgvVisitas = visitaRepositorio.GetDGVVisitasActuales(search);
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
            ingresoSalidaProcessor = FactoriaNegocio.Instancia.CreateIngresoProcessor(tipoVisita);   // se crea la instancia del ingreso segun el tipo de visita
            return ingresoSalidaProcessor.RegistrarIngreso(nombre, apellidos, placas, ubicacion, rostro, placaTrasera, placaDelantera, credencial, idVisita);
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
        /// <summary>
        /// Metodo para dar salida a la visita
        /// </summary>
        /// <param name="visita"> Implementacion de la clase que representa al actor "Visita"</param>
        /// <param name="placa"> foto de la placa trasera o delantera </param>
        /// <returns>registro de salida con exito  o fallo</returns>
        public bool DarSalida(Visita visita, Bitmap placa)
        {
            ingresoSalidaProcessor = FactoriaNegocio.Instancia.CreateIngresoProcessor(visita.TipoVisita.ID);
            int regCount = ingresoSalidaProcessor.RegistrarSalida(visita.ID, placa);
            if (regCount > 0)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public IngresoSalidaVisita GetUltimaVisita()
        {
            var ultimaVisita = ingresoSalidaVisitaRepositorio.GetUltimaSalida();
            return ultimaVisita;
        }
    }
}
