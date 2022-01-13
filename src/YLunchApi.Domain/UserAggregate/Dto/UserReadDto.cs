using Microsoft.AspNetCore.Identity;
using YLunchApi.Domain.Core.Utils;

namespace YLunchApi.Domain.UserAggregate.Dto;

public class UserReadDto
{
    public string Link { get; set; }
    public string Id { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
    public List<string> Roles { get; set; }

    public UserReadDto(User user, List<string> roles)
    {
        Id = user.Id;
        Link = $"{EnvironmentUtils.BaseUrl}/users/{Id}";
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        Firstname = user.Firstname;
        Lastname = user.Lastname;
        Roles = roles;
    }
}
