using System.ComponentModel.DataAnnotations;

namespace YnovEat.Domain.DTO.UserModels.Registration
{
    public class RegisterCustomerDto : RegisterUserDto
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }
    }
}
