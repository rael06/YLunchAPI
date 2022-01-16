using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.Domain.UserAggregate;

public interface IUserService
{
    Task<UserReadDto?> Create(UserCreateDto userCreateDto, string role);

    Task<User?> GetAuthenticatedUser(LoginRequestDto loginRequestDto);
}
