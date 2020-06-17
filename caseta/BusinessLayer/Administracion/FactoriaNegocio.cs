using BusinessInterfaces;
using DataLayer;
using ResidencialEnums;
using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class FactoriaNegocio
    {
        private static FactoriaNegocio instancia;

        private static object mutex = new object();
        public static FactoriaNegocio Instancia
        {
            get
            {
                lock (mutex)
                {
                    if (instancia == null)
                    {
                        instancia = new FactoriaNegocio();
                    }
                }
                return instancia;
            }
        }
        public IIngresoSalidaProcessor CreateIngresoProcessor(int tipoVisita)
        {
            if (tipoVisita == (int)TiposDeVisita.Preregistro)
            {
                return new PreregistroProcessor(new VisitaRepositorio(), new IngresoSalidaVisitaRepositorio());
            }
            else if (tipoVisita == (int)TiposDeVisita.Habitual)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }
        }
        
    }
}
