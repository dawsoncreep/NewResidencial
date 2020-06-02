using SecureGateTypes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Implementar los metodos de salida o entrada para diferentes tipos de visita
/// </summary>
namespace BusinessInterfaces
{
    public interface IIngresoSalidaProcessor
    {
        int RegistrarIngreso(string nombre, string apellidos, string placas, int idUbicacion, Bitmap rostro, Bitmap placaTrasera, Bitmap placaDelantera, Bitmap credencial, int? idVisita = null);
        int RegistrarSalida(int idVisita, Bitmap placa);
    }
}
