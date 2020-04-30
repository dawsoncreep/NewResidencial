using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces
{
    public interface IVisitaRepositorio
    {
        int SetVisita(Visita v);
        Visita GetVisitaByID(int id);
        void DesactivarVisita(int id);
        void UpdateFotoVisita(string urlfoto, int id);
        IEnumerable<DGVVisitaActual> GetDGVVisitasActuales();
        IEnumerable<DGVBusqueda> GetPreRegistros();
    }
}
