using Repository.Abstractions.Users.Models;

namespace Repository.Abstractions.Users
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsersAsync(CancellationToken cancellationToken);
    }
}
