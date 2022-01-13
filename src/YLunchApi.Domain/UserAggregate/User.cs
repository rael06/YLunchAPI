using Microsoft.AspNetCore.Identity;
using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.Domain.UserAggregate;

public sealed class User : IdentityUser
{
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }

    public User()
    {
    }

    public User(UserCreateDto userCreateDto)
    {
        Id = Guid.NewGuid().ToString();
        UserName = userCreateDto.Email;
        Email = userCreateDto.Email;
        PhoneNumber = userCreateDto.PhoneNumber;
        Firstname = userCreateDto.Firstname;
        Lastname = userCreateDto.Lastname;
    }
}
