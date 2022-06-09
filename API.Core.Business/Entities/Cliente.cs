using System.ComponentModel.DataAnnotations;

namespace API.Core.Business.Entities
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string? DNI { get; set; }

        [Required(ErrorMessage = "Este valor es requerido")]
        public string? Direccion { get; set; }



    }
}
