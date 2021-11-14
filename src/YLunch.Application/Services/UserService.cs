using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YLunch.Application.Exceptions;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.ModelsAggregate.UserAggregate;
using YLunch.Domain.Services.Database.Repositories;
using YLunch.Domain.Services.UserServices;

namespace YLunch.Application.Services
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

        public async Task<UserAsCustomerDetailsReadDto> GetAsCustomerById(string id)
        {
            User user = await _userRepository.GetAsCustomerById(id);
            return new UserAsCustomerDetailsReadDto(user);
        }

        public async Task DeleteUserByUsername(string username)
        {
            var user = await _userRepository.GetFullUser(username);
            if (user is null)
            {
                throw new NotFoundException($"User with username: '{username}' not found");
            }
            await _userRepository.Delete(user);
        }
    }
}
