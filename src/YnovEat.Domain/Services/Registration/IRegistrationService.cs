using System.Threading.Tasks;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.DTO.UserModels.Registration;

namespace YnovEat.Domain.Services.Registration
{
    public interface IRegistrationService
    {
        Task<UserReadDto> Register<T>(T userCreationDto) where T : UserCreationDto;
    }
}
