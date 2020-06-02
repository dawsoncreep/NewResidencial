using BusinessLayer;
using DataLayer;
using BusinessInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecureGateTypes;

namespace caseta
{
    public class Factoria
    {
        private static Factoria instancia;

        private static object mutex = new object();
        public static Factoria Instancia
        {
            get
            {
                lock (mutex)
                {
                    if (instancia == null)
                    {
                        instancia = new Factoria();
                    }
                }
                return instancia;
            }
        }

        public IVisitaProcessor CreateVisitaProcessor()
        {
            return new VisitaProcessor(new TipoVisitaRepositorio(), new VisitaRepositorio(), new IngresoSalidaVisitaRepositorio());
        }

        internal IUbicacionProcessor UbicacionProcessor()
        {
            return new UbicacionProcessor(new TipoUbicacionRepositorio(), new UbicacionRepositorio());
        }
    }
}
