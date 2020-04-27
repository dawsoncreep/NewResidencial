using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces
{
    public interface IIngresoSalidaVisitaRepositorio
    {
        int SetIngreso(int id, string placaDelantera, string placaTrasera, string cabina, string identificacion);
        int SetSalida(int idVisita, string fotoSalida);
    }
}
