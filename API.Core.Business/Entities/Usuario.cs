using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace API.Core.Business.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public Role Role { get; set; }

        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt{ get; set; }


    }
}
