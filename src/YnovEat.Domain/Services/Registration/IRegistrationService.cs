using System.Threading.Tasks;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.DTO.UserModels.Registration;

namespace YnovEat.Domain.Services.Registration
{
    public interface IRegistrationService
    {
        Task<UserDto> Register<T>(T registerCustomerDto) where T : RegisterUserDto;
    }
}
