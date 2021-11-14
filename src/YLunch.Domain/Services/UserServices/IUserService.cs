using System.Collections.Generic;
using System.Threading.Tasks;
using YLunch.Domain.DTO.UserModels;
using YLunch.Domain.ModelsAggregate.UserAggregate;

namespace YLunch.Domain.Services.UserServices
{
    public interface IUserService
    {
        Task<ICollection<UserReadDto>> GetAllUsers();
        Task<UserAsCustomerDetailsReadDto> GetAsCustomerById(string id);
        Task DeleteUserByUsername(string username);
    }
}
