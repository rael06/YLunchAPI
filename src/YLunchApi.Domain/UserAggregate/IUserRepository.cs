namespace YLunchApi.Domain.UserAggregate;

public interface IUserRepository
{
    Task Create(User user, string password);
    Task<User?> GetByEmail(string email);
}
