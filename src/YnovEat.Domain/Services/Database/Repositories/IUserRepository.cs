using System.Threading.Tasks;
using YnovEat.Domain.ModelsAggregate.UserAggregate;

namespace YnovEat.Domain.Services.Database.Repositories
{
    public interface IUserRepository
    {
        Task Register(User user, string password, string role);
    }
}
