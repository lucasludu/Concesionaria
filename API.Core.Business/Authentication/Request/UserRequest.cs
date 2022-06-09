using System.ComponentModel.DataAnnotations;

namespace API.Core.Business.Authentication.Request
{
    public class UserRequest
    {
        [Required(ErrorMessage = "Este valor es requerido")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Este valor es requerido")]
        public string? Password { get; set; }
    }
}
