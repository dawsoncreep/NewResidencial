using ResidencialEnums;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces
{
    public interface IDispositivoRepositorio
    {
        Dispositivo GetDispositivo(TiposDispositivos device);
    }
}
