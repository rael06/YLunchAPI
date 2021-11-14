using YLunch.Domain.DTO.UserModels.Registration;
using YLunch.Domain.Services.Database.Repositories;

namespace YLunch.Application.Services.RegistrationServices
{
    public interface IRegistrationStrategyFactory
    {
        SuperAdminRegistrationStrategy Create(IUserRepository userRepository, SuperAdminCreationDto superAdminCreationDto);
        CustomerRegistrationStrategy Create(IUserRepository userRepository, CustomerCreationDto customerCreationDto);
        RestaurantOwnerRegistrationStrategy Create(IUserRepository userRepository, RestaurantOwnerCreationDto restaurantOwnerCreationDto);
        RestaurantAdminRegistrationStrategy Create(IUserRepository userRepository, RestaurantAdminCreationDto restaurantAdminCreationDto);
        EmployeeRegistrationStrategy Create(IUserRepository userRepository, EmployeeCreationDto employeeCreationDto);
    }
}
