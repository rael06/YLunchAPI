using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.Services.Database.Repositories;
using YnovEat.Domain.Services.UserServices;

namespace YnovEat.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(
            IUserRepository userRepository

        )
        {
            _userRepository = userRepository;
        }

        public async Task<ICollection<UserReadDto>> GetAllUsers()
        {
            var users = await _userRepository.GetFullUsers();
            return users.Select(x => new UserReadDto(x)).ToList();
        }
    }
}
