using YLunchApi.Domain.CommonAggregate;

namespace YLunchApi.Domain.UserAggregate.Dto;

public class UserReadDto : EntityReadDto
{
    private const string ResourcesName = $"{nameof(User)}s";
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string Firstname { get; set; } = null!;
    public string Lastname { get; set; } = null!;
    public List<string> Roles { get; set; } = null!;

    public UserReadDto()
    {
    }

    public UserReadDto(string id, string email, string phoneNumber, string firstname, string lastname,
        List<string> roles) : base(id, ResourcesName)
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
