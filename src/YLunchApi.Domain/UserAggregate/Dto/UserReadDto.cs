using Microsoft.AspNetCore.Identity;
using YLunchApi.Domain.CommonAggregate;
using YLunchApi.Domain.Core.Utils;

namespace YLunchApi.Domain.UserAggregate.Dto;

public class UserReadDto : EntityReadDto
{
    private const string ResourcesName = $"{nameof(User)}s";
    public string Email { get; }
    public string PhoneNumber { get; }
    public string Firstname { get; }
    public string Lastname { get; }
    public List<string> Roles { get; }

    public UserReadDto(string id, string email, string phoneNumber, string firstname, string lastname, List<string> roles) : base(id, ResourcesName)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        Firstname = firstname;
        Lastname = lastname;
        Roles = roles;
    }

    public UserReadDto(User user, List<string> roles) : base(user.Id, ResourcesName)
    {
        Email = user.Email;
        PhoneNumber = user.PhoneNumber;
        Firstname = user.Firstname;
        Lastname = user.Lastname;
        Roles = roles;
    }
}
