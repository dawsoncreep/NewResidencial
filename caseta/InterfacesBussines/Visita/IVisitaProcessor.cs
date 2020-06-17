using ResidencialEnums;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessInterfaces
{
    public interface IVisitaProcessor
    {
        IEnumerable<TipoVisita> TiposDeVisita();
        int RegistrarVisita(Bitmap rostro, Bitmap placaTrasera, Bitmap placaDelantera, Bitmap credencial, int tipoVisita, 
            string nombre, string apellidos, string descripcion, string placas, int ubicacion, int? idVisita);
        IEnumerable<DGVVisitaActual> GetVisitasActuales(string search = "");
        IEnumerable<DGVBusqueda> GetDGVBusquedas(string search = "");
        Visita GetVisitaByID(int id);
        int GetNumVisitas(TiposDeVisita tipoVisita);
        bool DarSalida(Visita visita, Bitmap placa);
        IngresoSalidaVisita GetUltimaVisita();
    }
}
