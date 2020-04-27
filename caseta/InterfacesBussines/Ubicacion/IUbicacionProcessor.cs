using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessInterfaces
{
    public interface IUbicacionProcessor
    {
        IEnumerable<Ubicacion> TodasLasUbicaciones();
        IEnumerable<Ubicacion> UbicacionesValidas();
        IEnumerable<TipoUbicacion> TiposDeUbicacion();
    }
}
