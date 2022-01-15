using System.ComponentModel.DataAnnotations;

namespace YLunchApi.Domain.UserAggregate.Dto;

public abstract class UserCreateDto
{
    [Required]
    [RegularExpression(
        @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*\.[a-zA-Z]{2,20}$",
        ErrorMessage = "Email is invalid.")]
    public virtual string Email { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[.@$!%*?&])[A-Za-z\d.@$!%*?&]{8,}$",
        ErrorMessage =
            "Password is not allowed. Must contain at least 8 characters, 1 lowercase letter, 1 uppercase letter, 1 special character and 1 number.")]
    public string Password { get; set; } = null!;

    [Required]
    [RegularExpression(
        @"^0[6-7][0-9]{8}$",
        ErrorMessage = "PhoneNumber is not allowed. Example: 0612345678.")]
    public string PhoneNumber { get; set; } = null!;

    [Required] public string Firstname { get; set; } = null!;

    [Required] public string Lastname { get; set; } = null!;
}
