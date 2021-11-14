using System.Threading.Tasks;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.DTO.UserModels.Registration;

namespace YLunch.Domain.Services.Registration
{
    public interface IRegistrationService
    {
        Task<UserReadDto> Register(SuperAdminCreationDto superAdminCreationDto);
        Task<UserReadDto> Register(RestaurantOwnerCreationDto restaurantOwnerCreationDto);
        Task<UserReadDto> Register(RestaurantAdminCreationDto restaurantAdminCreationDto);
        Task<UserReadDto> Register(EmployeeCreationDto employeeCreationDto);
        Task<UserReadDto> Register(CustomerCreationDto customerCreationDto);
    }
}
