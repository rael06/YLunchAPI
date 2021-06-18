using System.Collections.Generic;
using System.Threading.Tasks;
using YnovEat.Domain.DTO.UserModels;

namespace YnovEat.Domain.Services.UserServices
{
    public interface IUserService
    {
        Task<ICollection<UserReadDto>> GetAllUsers();
    }
}
