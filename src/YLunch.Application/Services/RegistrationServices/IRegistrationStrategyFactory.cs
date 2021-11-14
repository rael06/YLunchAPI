using YLunch.Domain.DTO.UserModels.Registration;
using YLunch.Domain.Services.Database.Repositories;

namespace YLunch.Application.Services.RegistrationServices
{
    public interface IRegistrationStrategyFactory
    {
        AbstractRegistrationStrategy Create(UserCreationDto userCreationDto);
    }
}
