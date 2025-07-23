using FastEndpoints;
using Finbuckle.MultiTenant;
using Services.Abstractions;
using Services.Abstractions.Models.Users;

namespace WebAPI.Features.Users
{
    public class GetUsersEndpoint(IUserService _service) : EndpointWithoutRequest<List<UserDto>>
    {
        
        public override void Configure()
        {
            Get("/users");
            AllowAnonymous();
        }

        public override async Task HandleAsync(CancellationToken cancellationToken)
        {
            try
            {
                var users = await _service.GetUsersAsync(cancellationToken);
                await SendAsync(users, cancellation: cancellationToken);
            }
            catch (MultiTenantException) {
                await SendForbiddenAsync(cancellationToken);
            }
            catch(Exception)
            {
                await SendErrorsAsync(500, cancellationToken);
            }
        }
    }
}
