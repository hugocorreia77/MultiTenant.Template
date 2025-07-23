namespace Core.Server.Abstractions.Tenant
{
    public interface ITenantableObject
    {
        public string TenantId { get; set; }
    }
}
