using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessInterfaces
{
    public interface IVisitaProcessor
    {
        IEnumerable<TipoVisita> TiposDeVisita();
        void RegistrarVisita(Bitmap rostro, Bitmap placaTrasera, Bitmap placaDelantera, Bitmap credencial, int tipoVisita, 
            string nombre, string apellidos, string descripcion, string placas, int ubicacion);
    }
}
