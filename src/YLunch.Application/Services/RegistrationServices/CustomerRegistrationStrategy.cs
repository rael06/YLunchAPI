using System.Threading.Tasks;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.DTO.UserModels.Registration;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.ModelsAggregate.UserAggregate.Roles;
using YLunch.Domain.Services.Database.Repositories;

namespace YLunch.Application.Services.RegistrationServices
{
    public class CustomerRegistrationStrategy : AbstractRegistrationStrategy
    {
        public CustomerRegistrationStrategy(IUserRepository userRepository) : base(userRepository)
        {
        }

        public override async Task<UserReadDto> Register(UserCreationDto userCreationDto)
        {
            var user = User.Create((CustomerCreationDto) userCreationDto);

            await _userRepository.Register(user, userCreationDto.Password, UserRoles.SuperAdmin);

            return new UserReadDto(user);
        }
    }
}
