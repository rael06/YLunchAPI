using System;
using System.Threading.Tasks;
using YnovEat.Application.Exceptions;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.DTO.UserModels.Registration;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.Registration;

namespace YnovEat.Application.Services
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRestaurantRepository _restaurantRepository;

        public RegistrationService(
            IUserRepository userRepository,
            IRestaurantRepository restaurantRepository
        )
        {
            _userRepository = userRepository;
            _restaurantRepository = restaurantRepository;
        }

        private async Task<UserDto> Register(RegisterSuperAdminDto registerUserDto)
        {
            var user = new Domain.ModelsAggregate.UserAggregate.User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUserDto.Username,
                Lastname = registerUserDto.Lastname,
                Firstname = registerUserDto.Firstname
            };

            await _userRepository.Register(user, registerUserDto.Password);

            return new UserDto(user);
        }

        private async Task<UserDto> Register(RegisterRestaurantAdminDto registerUserDto)
        {
            var user = new Domain.ModelsAggregate.UserAggregate.User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUserDto.Username,
                Lastname = registerUserDto.Lastname,
                Firstname = registerUserDto.Firstname
            };

            await _userRepository.Register(user, registerUserDto.Password);
            await _restaurantRepository.AddAdmin(user);

            return new UserDto(user);
        }

        private async Task<UserDto> Register(RegisterEmployeeDto registerUserDto)
        {
            var user = new Domain.ModelsAggregate.UserAggregate.User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUserDto.Username,
                Lastname = registerUserDto.Lastname,
                Firstname = registerUserDto.Firstname
            };

            await _userRepository.Register(user, registerUserDto.Password);

            return new UserDto(user);
        }

        private async Task<UserDto> Register(RegisterCustomerDto registerUserDto)
        {
            var user = new Domain.ModelsAggregate.UserAggregate.User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUserDto.Username,
                Lastname = registerUserDto.Lastname,
                Firstname = registerUserDto.Firstname,
                Email = registerUserDto.Username,
                PhoneNumber = registerUserDto.PhoneNumber,
                CreationDateTime = DateTime.Now,
            };

            await _userRepository.Register(user, registerUserDto.Password);

            return new UserDto(user);
        }

        public async Task<UserDto> Register<T>(T registerUserDto) where T : RegisterUserDto
        {
            return registerUserDto switch
            {
                RegisterSuperAdminDto registerSuperAdminDto => await Register(registerSuperAdminDto),
                RegisterRestaurantAdminDto registerRestaurantAdminDto => await Register(registerRestaurantAdminDto),
                RegisterEmployeeDto registerEmployeeDto => await Register(registerEmployeeDto),
                RegisterCustomerDto registerCustomerDto => await Register(registerCustomerDto),
                _ => throw new UserRegistrationException()
            };
        }
    }
}
