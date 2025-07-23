using Microsoft.Extensions.DependencyInjection;
using Repository.Abstractions.Users;
using Services.Abstractions;
using Services.Abstractions.Models.Users;

namespace Services.Users
{
    public sealed class UserService(IServiceProvider serviceProvider) : IUserService
    {
        private IUserRepository _userRepository => serviceProvider.GetRequiredService<IUserRepository>();

        public Task<List<UserDto>> GetUsersAsync(CancellationToken cancellationToken = default)
            => _userRepository.GetUsersAsync(cancellationToken)
                .ContinueWith(task => task.Result.Select(user => new UserDto
                {
                    Id = user.Id,
                    Name = user.Name
                }).ToList(), cancellationToken);
    }
}
