using System.Collections.Generic;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.UserModels;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.Services.UserServices
{
    public interface IUserService
    {
        Task<ICollection<UserReadDto>> GetAllUsers();
        Task<UserAsCustomerDetailsReadDto> GetAsCustomerById(string id);
    }
}
