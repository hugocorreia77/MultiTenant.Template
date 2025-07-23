using Finbuckle.MultiTenant.Abstractions;

namespace Core.Server.Abstractions.Tenant
{
    public class AppTenantInfo : ITenantInfo
    {
        public string? Id { get; set; }
        public string? Identifier { get; set; }
        public string? Name { get; set; }
    }
}
