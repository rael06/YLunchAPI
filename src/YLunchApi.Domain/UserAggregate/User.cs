using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using YLunchApi.Domain.Core.Utils;
using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.Domain.UserAggregate;

public sealed class User : IdentityUser
{
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;

    [ExcludeFromCodeCoverage]
    public User()
    {
    }

    public User(UserCreateDto userCreateDto)
    {
        Id = Guid.NewGuid().ToString();
        UserName = userCreateDto.Email.ToLower();
        Email = userCreateDto.Email.ToLower();
        PhoneNumber = userCreateDto.PhoneNumber;
        Firstname = userCreateDto.Firstname.Capitalize();
        Lastname = userCreateDto.Lastname.Capitalize();
    }
}
