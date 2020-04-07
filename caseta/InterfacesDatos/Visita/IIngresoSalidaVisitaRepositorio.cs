using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces
{
    public interface IIngresoSalidaVisitaRepositorio
    {
        void SetIngreso(int id, string placaDelantera, string placaTrasera, string cabina, string identificacion);
        void SetSalida(int idVisita, string fotoSalida);
    }
}
