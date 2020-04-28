
using BusinessInterfaces;
using DataInterfaces;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class UbicacionProcessor : IUbicacionProcessor
    {
        private readonly ITipoUbicacionRepositorio TipoUbicacionRepositorio;
        private readonly IUbicacionesRepositorio UbicacionesRepositorio;
        public UbicacionProcessor(ITipoUbicacionRepositorio _tipoUbicacionRepositorio, IUbicacionesRepositorio _ubicacionesRepositorio)
        {
            TipoUbicacionRepositorio = _tipoUbicacionRepositorio;
            UbicacionesRepositorio = _ubicacionesRepositorio;
        }
        public IEnumerable<TipoUbicacion> TiposDeUbicacion()
        {
            IEnumerable<TipoUbicacion> tiposUbicacion = TipoUbicacionRepositorio.GetTipoUbicaciones();
            return tiposUbicacion;
        }

        public IEnumerable<Ubicacion> TodasLasUbicaciones()
        {
            IEnumerable<Ubicacion> ubicaciones = UbicacionesRepositorio.GetAllUbicacions();
            return ubicaciones;
        }

        public IEnumerable<Ubicacion> UbicacionesValidas()
        {
            IEnumerable<Ubicacion> ubicaciones = UbicacionesRepositorio.UbicacionesValidas();
            return ubicaciones;
        }
    }
}
