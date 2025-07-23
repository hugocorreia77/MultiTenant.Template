using Core.Server.Abstractions.Tenant;

namespace Repository.Abstractions.Users.Models
{
    public class User : ITenantableObject
    {
        public required string TenantId { get; set; }
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
