using System.ComponentModel.DataAnnotations;

namespace YLunchApi.Domain.UserAggregate.Dto;

public abstract class UserCreateDto
{
    [Required]
    [EmailAddress]
    [RegularExpression(@"^.*@\w+\-?\w+\.\w+$", ErrorMessage = "Email is invalid")]
    public virtual string Email { get; set; } = null!;

    [Required]
    [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%&*.,; ])[A-Za-z\d!@#$%&*.,; ]{8,}$", ErrorMessage = "Password is not allowed. Must contain at least 8 characters, 1 lowercase letter, 1 uppercase letter, 1 special character and 1 number")]
    public string Password { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    public string? Firstname { get; set; } = null!;

    [Required]
    public string? Lastname { get; set; } = null!;
}
