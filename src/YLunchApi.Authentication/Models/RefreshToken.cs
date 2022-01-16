using System.ComponentModel.DataAnnotations;
using YLunchApi.Domain.UserAggregate;

namespace YLunchApi.Authentication.Models;

public class RefreshToken
{
    public string Id { get; set; } = null!;
    [Required] public string UserId { get; set; } = null!;
    public string Token { get; set; } = null!;
    public string JwtId { get; set; } = null!;
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }
    public DateTime CreationDateTime { get; set; }
    public DateTime ExpirationDateTime { get; set; }

    public virtual User User { get; set; } = null!;
}
