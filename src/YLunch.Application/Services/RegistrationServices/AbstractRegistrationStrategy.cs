using System.Threading.Tasks;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.DTO.UserModels.Registration;
using YLunch.Domain.Services.Database.Repositories;

namespace YLunch.Application.Services.RegistrationServices
{
    public abstract class AbstractRegistrationStrategy
    {
        protected readonly IUserRepository _userRepository;

        protected AbstractRegistrationStrategy(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public abstract Task<UserReadDto> Register(UserCreationDto userCreationDto);
    }
}
