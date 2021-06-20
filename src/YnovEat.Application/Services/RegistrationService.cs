using System;
using System.Threading.Tasks;
using YnovEat.Application.Exceptions;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.DTO.UserModels.Registration;
using YnovEat.Domain.ModelsAggregate.CustomerAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate;
using YnovEat.Domain.ModelsAggregate.UserAggregate.Roles;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.Registration;
using YnovEat.DomainShared.RestaurantAggregate.Enums;

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

        private async Task<UserReadDto> Register(SuperAdminCreationDto userCreationDto)
        {
            var user = User.Create(userCreationDto);

            await _userRepository.Register(user, userCreationDto.Password, UserRoles.SuperAdmin);

            return new UserReadDto(user);
        }

        private async Task<UserReadDto> Register(RestaurantAdminCreationDto userCreationDto)
        {
            var user = User.Create(userCreationDto);

            await _userRepository.Register(user, userCreationDto.Password, UserRoles.RestaurantAdmin);

            return new UserReadDto(user);
        }

        private async Task<UserReadDto> Register(EmployeeCreationDto userCreationDto)
        {
            var user = User.Create(userCreationDto);

            await _userRepository.Register(user, userCreationDto.Password, UserRoles.Employee);

            return new UserReadDto(user);
        }

        private async Task<UserReadDto> Register(CustomerCreationDto userCreationDto)
        {
            var user = User.Create(userCreationDto);

            await _userRepository.Register(user, userCreationDto.Password, UserRoles.Customer);

            return new UserReadDto(user);
        }

        public async Task<UserReadDto> Register<T>(T userCreationDto) where T : UserCreationDto
        {
            return userCreationDto switch
            {
                SuperAdminCreationDto registerSuperAdminDto => await Register(registerSuperAdminDto),
                RestaurantAdminCreationDto registerRestaurantAdminDto => await Register(registerRestaurantAdminDto),
                EmployeeCreationDto registerEmployeeDto => await Register(registerEmployeeDto),
                CustomerCreationDto registerCustomerDto => await Register(registerCustomerDto),
                _ => throw new UserRegistrationException()
            };
        }
    }
}
