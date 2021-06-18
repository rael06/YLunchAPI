using System;
using System.Threading.Tasks;
using YnovEat.Application.Exceptions;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.DTO.UserModels.Registration;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
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

        private async Task<UserReadDto> Register(RegisterSuperAdminDto registerUserDto)
        {
            var user = new User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUserDto.Username,
                Lastname = registerUserDto.Lastname,
                Firstname = registerUserDto.Firstname,
                CreationDateTime = DateTime.Now,
            };

            await _userRepository.Register(user, registerUserDto.Password, UserRoles.SuperAdmin);

            return new UserReadDto(user);
        }

        private async Task<UserReadDto> Register(RegisterRestaurantAdminDto registerUserDto)
        {
            var user = new Domain.ModelsAggregate.UserAggregate.User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUserDto.Username,
                Lastname = registerUserDto.Lastname,
                Firstname = registerUserDto.Firstname,
                CreationDateTime = DateTime.Now,
            };

            await _userRepository.Register(user, registerUserDto.Password, UserRoles.RestaurantAdmin);
            await _restaurantRepository.AddAdmin(user);

            return new UserReadDto(user);
        }

        private async Task<UserReadDto> Register(RegisterEmployeeDto registerUserDto)
        {
            var user = new Domain.ModelsAggregate.UserAggregate.User
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUserDto.Username,
                Lastname = registerUserDto.Lastname,
                Firstname = registerUserDto.Firstname,
                CreationDateTime = DateTime.Now,
            };

            await _userRepository.Register(user, registerUserDto.Password, UserRoles.Employee);

            return new UserReadDto(user);
        }

        private async Task<UserReadDto> Register(RegisterCustomerDto registerUserDto)
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

            await _userRepository.Register(user, registerUserDto.Password, UserRoles.Customer);

            return new UserReadDto(user);
        }

        public async Task<UserReadDto> Register<T>(T registerUserDto) where T : RegisterUserDto
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
