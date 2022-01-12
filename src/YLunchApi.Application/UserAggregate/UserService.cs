using Microsoft.AspNetCore.Identity;
using YLunchApi.Domain.Core.Exceptions;
using YLunchApi.Domain.UserAggregate;
using YLunchApi.Domain.UserAggregate.Dto;

namespace YLunchApi.Application.UserAggregate;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<RestaurantOwnerReadDto> Create(RestaurantOwnerCreateDto restaurantOwnerCreateDto)
    {
        var user = new User
        {
            Id = Guid.NewGuid().ToString(),
            UserName = restaurantOwnerCreateDto.Email,
            Email = restaurantOwnerCreateDto.Email,
            PhoneNumber = restaurantOwnerCreateDto.PhoneNumber,
            Firstname = restaurantOwnerCreateDto.Firstname,
            Lastname = restaurantOwnerCreateDto.Lastname
        };

        await _userRepository.Create(user, restaurantOwnerCreateDto.Password);

        var userDb = await _userRepository.GetByEmail(user.Email);
        if (userDb == null)
        {
            throw new EntityNotFoundException();
        }

        return new RestaurantOwnerReadDto
        {
            Id = userDb.Id,
            Email = userDb.Email,
            PhoneNumber = userDb.PhoneNumber,
            Firstname = userDb.Firstname,
            Lastname = userDb.Lastname
        };
    }
}
