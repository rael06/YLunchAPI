using System.Threading.Tasks;
using YnovEat.Application.DTO.UserModels;
using YnovEat.Application.DTO.UserModels.Registration;

namespace YnovEat.Application.Services
{
    public interface IRegistrationService
    {
        Task<UserDto> Register<T>(T registerCustomerDto) where T : RegisterUserDto;
    }
}
