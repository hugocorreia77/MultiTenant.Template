using Services.Abstractions.Models.Users;

namespace Services.Abstractions
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUsersAsync(CancellationToken cancellationToken = default);
    }
}
