using System.Threading.Tasks;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.DTO.UserModels.Registration;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.ModelsAggregate.UserAggregate.Roles;
using YLunch.Domain.Services.Database.Repositories;
using YLunch.Domain.Services.Registration;

namespace YLunch.Application.Services.RegistrationServices
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUserRepository _userRepository;
        private readonly RegistrationStrategyFactory _registrationStrategyFactory;

        public RegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _registrationStrategyFactory = new RegistrationStrategyFactory(_userRepository);
        }

        public Task<UserReadDto> Register(UserCreationDto userCreationDto)
        {
            var registrationStrategy = _registrationStrategyFactory.Create(userCreationDto);
            return registrationStrategy.Register(userCreationDto);
        }
    }
}
