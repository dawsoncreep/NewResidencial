using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessInterfaces
{
    public interface IIngresoProcessor
    {
        int RegistrarIngreso(string nombre, string apellidos, string placas, int idUbicacion);
        void GuardarCapturas(Bitmap rostro, Bitmap placaTrasera, Bitmap placaDelantera, Bitmap credencial, int id);
    }
}
