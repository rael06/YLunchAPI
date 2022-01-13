using System.ComponentModel.DataAnnotations;

namespace YLunchApi.Domain.UserAggregate.Dto;

public class CustomerCreateDto : UserCreateDto
{
    [Required]
    [EmailAddress]
    [RegularExpression(@"^.*@ynov.com$", ErrorMessage = "Email is not allowed. You must provide your Ynov email")]
    public override string Email { get; set; } = null!;
}
