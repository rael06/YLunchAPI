using System.ComponentModel.DataAnnotations;

namespace YLunchApi.Domain.UserAggregate.Dto;

public class LoginRequestDto
{
    [Required] public virtual string Email { get; set; } = null!;

    [Required] public string Password { get; set; } = null!;
}
