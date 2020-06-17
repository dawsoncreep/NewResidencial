using DataInterfaces;
using ResidencialEnums;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class DispositivoRepositorio : IDispositivoRepositorio
    {
        public string ConnString { get; set; }
        public DispositivoRepositorio()
        {
            ConnString = ConfigurationManager.ConnectionStrings["SecureGateEntities"].ConnectionString;
        }
        public Dispositivo GetDispositivo(TiposDispositivos device)
        {
            Dispositivo dev;
            using (IDispositivoDBContext context = new GeneralContext(ConnString))
            {
                dev = context.Dispositivos.Where(w => w.tipoDispositivo == device.ToString()).Select(s => new Dispositivo {
                    Activo = s.activo,
                    IdDispositivo = s.idDispositivo,
                    Ip = s.Ip,
                    Password = s.password,
                    Protocolo = s.protocolo,
                    Puerto = s.puerto,
                    TipoDispositivo = s.tipoDispositivo,
                    Usuario = s.usuario,
                    Ubicacion = new Ubicacion { ID = s.idUbicacion }
                }).FirstOrDefault();
            }
            return dev;  
        }
    }
}
