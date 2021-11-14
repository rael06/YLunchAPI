using System.Runtime.InteropServices;
using YLunch.Application.Exceptions;
using YLunch.Domain.DTO.UserModels.Registration;
using YLunch.Domain.Services.Database.Repositories;

namespace YLunch.Application.Services.RegistrationServices
{
    public class RegistrationStrategyFactory:IRegistrationStrategyFactory
    {
        private static readonly RegistrationStrategyFactory _instance;
        public static readonly RegistrationStrategyFactory Instance = _instance ??= new RegistrationStrategyFactory();

        private RegistrationStrategyFactory()
        {
        }

        public SuperAdminRegistrationStrategy Create(IUserRepository userRepository, SuperAdminCreationDto superAdminCreationDto)
        {
            return new (userRepository);
        }

        public CustomerRegistrationStrategy Create(IUserRepository userRepository, CustomerCreationDto customerCreationDto)
        {
            return new (userRepository);
        }

        public RestaurantOwnerRegistrationStrategy Create(IUserRepository userRepository,
            RestaurantOwnerCreationDto restaurantOwnerCreationDto)
        {
            return new (userRepository);
        }

        public RestaurantAdminRegistrationStrategy Create(IUserRepository userRepository,
            RestaurantAdminCreationDto restaurantAdminCreationDto)
        {
            return new (userRepository);
        }

        public EmployeeRegistrationStrategy Create(IUserRepository userRepository, EmployeeCreationDto employeeCreationDto)
        {
            return new (userRepository);
        }
    }
}
