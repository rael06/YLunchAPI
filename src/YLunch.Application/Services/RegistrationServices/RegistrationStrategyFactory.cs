using System.Runtime.InteropServices;
using YLunch.Application.Exceptions;
using YLunch.Domain.DTO.UserModels.Registration;
using YLunch.Domain.Services.Database.Repositories;

namespace YLunch.Application.Services.RegistrationServices
{
    public class RegistrationStrategyFactory : IRegistrationStrategyFactory
    {
        private readonly IUserRepository _userRepository;

        public RegistrationStrategyFactory(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public AbstractRegistrationStrategy Create(UserCreationDto userCreationDto)
        {
            return userCreationDto switch
            {
                SuperAdminCreationDto => new SuperAdminRegistrationStrategy(_userRepository),
                CustomerCreationDto => new CustomerRegistrationStrategy(_userRepository),
                RestaurantOwnerCreationDto => new RestaurantOwnerRegistrationStrategy(_userRepository),
                RestaurantAdminCreationDto => new RestaurantAdminRegistrationStrategy(_userRepository),
                EmployeeCreationDto => new EmployeeRegistrationStrategy(_userRepository),
                // Todo implement exception strategy
                _ => throw new UserRegistrationException()
            };
        }
    }
}
