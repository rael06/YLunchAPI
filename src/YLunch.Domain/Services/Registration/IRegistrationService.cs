using System.Threading.Tasks;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.DTO.UserModels.Registration;

namespace YLunch.Domain.Services.Registration
{
    public interface IRegistrationService
    {
        Task<UserReadDto> Register<T>(T userCreationDto) where T : UserCreationDto;
    }
}
