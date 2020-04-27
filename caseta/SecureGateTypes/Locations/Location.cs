using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecureGateTypes
{
    public class Location
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Calle { get; set; }
        public string NumeroExterno { get; set; }
        public string NumeroInterno { get; set; }

        public string LocationStr
        {
            get
            {
                return Calle + " #" + NumeroExterno + (NumeroInterno != null ? NumeroInterno : "");
            }
        }        
    }
}
