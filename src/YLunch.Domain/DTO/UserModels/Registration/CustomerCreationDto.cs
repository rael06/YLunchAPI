using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace YLunch.Domain.DTO.UserModels.Registration
{
    public class CustomerCreationDto : UserCreationDto
    {
        [Required(ErrorMessage = "Phone number is required")]
        public string PhoneNumber { get; set; }

        public override bool IsValid()
        {
            Match m = Regex.Match(UserName, "^.+@ynov.com$", RegexOptions.IgnoreCase);
            return m.Success;
        }
    }
}
