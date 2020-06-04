using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessInterfaces
{
    public interface IDispositivoProcessor
    {
        Dispositivo GetDispositivo(TiposDispositivos tipoDispositivo);
        string GetDispositivoString(TiposDispositivos tipoDispositivo);
    }
}
