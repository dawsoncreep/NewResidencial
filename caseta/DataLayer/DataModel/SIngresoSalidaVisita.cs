using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    [Table("ingresoSalidaVisita")]
    public class SIngresoSalidaVisita
    {
        [Key]
        public int Id { get; set; }
        public int idVisita { get; set; }
        public DateTime fechaIngreso { get; set; }
        public string fotoPlacaDelantera { get; set; }
        public string fotoPlacaTrasera { get; set; }
        public string fotoCabina { get; set; }
        public string fotoIdentificacion { get; set; }
        public DateTime? fechaSalida { get; set; }
        public string fotoSalidaUrl { get; set; }
    }
}
