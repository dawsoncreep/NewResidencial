using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces
{
    public interface IUbicacionesRepositorio
    {
        Ubicacion GetUbicacionByID(int id);
        IEnumerable<Ubicacion> GetAllUbicacions();
        IEnumerable<Ubicacion> GetUbicacionsByType(int idType);
        IEnumerable<Ubicacion> UbicacionesValidas();
    }
}
