using System.Collections.Generic;
using System.Threading.Tasks;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.Services.Database.Repositories
{
    public interface IUserRepository
    {
        Task Register(User user, string password, string role);
        Task<User> GetFullUser(string username);
        Task<ICollection<User>> GetFullUsers();
        Task<User> GetAsCustomerById(string id);
    }
}
