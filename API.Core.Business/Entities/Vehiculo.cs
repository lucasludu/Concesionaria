using API.Core.Business.Filtros;
using System.ComponentModel.DataAnnotations;

namespace API.Core.Business.Entities
{
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string? Marca { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string? Modelo { get; set; }

        [ModelCar(2015)]
        public int DateModel { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public float Precio { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaBaja { get; set; }


    }
}
