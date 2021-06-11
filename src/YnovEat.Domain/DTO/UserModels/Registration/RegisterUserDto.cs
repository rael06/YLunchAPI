using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.DTO.UserModels.Registration
{
    public abstract class RegisterUserDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }
    }
}
