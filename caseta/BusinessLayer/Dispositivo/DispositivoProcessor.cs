using BusinessInterfaces;
using DataInterfaces;
using DataLayer;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class DispositivoProcessor : IDispositivoProcessor
    {
        public IDispositivoRepositorio dispositivoRepositorio { get; set; }
        public DispositivoProcessor(IDispositivoRepositorio _dispositivoRepositorio)
        {
            dispositivoRepositorio = _dispositivoRepositorio;
        }
        public Dispositivo GetDispositivo(TiposDispositivos tipoDispositivo)
        {
            Dispositivo disp = dispositivoRepositorio.GetDispositivo(tipoDispositivo);
            return disp;
        }

        public string GetDispositivoString(TiposDispositivos tipoDispositivo)
        {
            Dispositivo disp = dispositivoRepositorio.GetDispositivo(tipoDispositivo);
            StringBuilder str = new StringBuilder();
            str.Append(disp.Protocolo);
            str.Append("://");
            str.Append(disp.Usuario);
            str.Append(":");
            str.Append(disp.Password);
            str.Append("@");
            str.Append(disp.Ip);
            str.Append(":");
            str.Append(disp.Puerto);
            return str.ToString();
        }
    }
}
