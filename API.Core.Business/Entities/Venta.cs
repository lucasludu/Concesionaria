using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Core.Business.Entities
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public double Importe { get; set; }

        public double Descuento { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [ForeignKey("Vehiculo")]
        public int VehiculoId { get; set; }

        public Vehiculo? Vehiculo { get; set; }

        [ForeignKey("Cliente")]
        public int ClienteId { get; set; }

        public Cliente? Cliente { get; set; }
    }
}
