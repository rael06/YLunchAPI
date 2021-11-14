using System.Threading.Tasks;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.DTO.UserModels.Registration;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.ModelsAggregate.UserAggregate.Roles;
using YLunch.Domain.Services.Database.Repositories;
using YLunch.Domain.Services.Registration;

namespace YLunch.Application.Services.RegistrationServices
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;

        public RegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserReadDto> Register(SuperAdminCreationDto superAdminCreationDto)
        {
            var user = User.Create(superAdminCreationDto);

            await _userRepository.Register(user, superAdminCreationDto.Password, UserRoles.SuperAdmin);

            return new UserReadDto(user);
        }

        public async Task<UserReadDto> Register(RestaurantOwnerCreationDto restaurantOwnerCreationDto)
        {
            var user = User.Create(restaurantOwnerCreationDto);

            await _userRepository.Register(user, restaurantOwnerCreationDto.Password, UserRoles.RestaurantAdmin);

            return new UserReadDto(user);
        }

        public async Task<UserReadDto> Register(RestaurantAdminCreationDto restaurantAdminCreationDto)
        {
            var user = User.Create(restaurantAdminCreationDto);

            await _userRepository.Register(user, restaurantAdminCreationDto.Password, UserRoles.RestaurantAdmin);

            return new UserReadDto(user);
        }

        public async Task<UserReadDto> Register(EmployeeCreationDto employeeCreationDto)
        {
            var user = User.Create(employeeCreationDto);

            await _userRepository.Register(user, employeeCreationDto.Password, UserRoles.Employee);

            return new UserReadDto(user);
        }

        public async Task<UserReadDto> Register(CustomerCreationDto customerCreationDto)
        {
            var user = User.Create(customerCreationDto);

            await _userRepository.Register(user, customerCreationDto.Password, UserRoles.Customer);

            return new UserReadDto(user);
        }
    }
}
