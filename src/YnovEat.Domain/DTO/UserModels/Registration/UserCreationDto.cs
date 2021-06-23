using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace YnovEat.Domain.DTO.UserModels.Registration
{
    public abstract class UserCreationDto
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Firstname is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required")]
        public string Lastname { get; set; }

        public abstract bool IsValid();
    }
}
