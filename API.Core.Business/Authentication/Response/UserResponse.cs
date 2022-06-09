using API.Core.Business.Entities;
using System.ComponentModel.DataAnnotations;

namespace API.Core.Business.Authentication.Response
{
    public class UserResponse
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public Role Role { get; set; }
    }
}

