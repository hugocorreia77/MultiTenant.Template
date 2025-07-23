using Core.Server.Abstractions.Tenant;
using FastEndpoints;
using Finbuckle.MultiTenant;
using Finbuckle.MultiTenant.Abstractions;
using Repository.Abstractions.Configurations.MongoDb;
using Repository.Abstractions.Configurations.MySql;
using Repository.Abstractions.Users;
using Repository.MongoDb.Users;
using Repository.MySql.Users;
using Repository.TenantControlPlane;
using Services.Abstractions;
using Services.Users;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();

builder.Services.AddMultiTenant<AppTenantInfo>()
    .WithHostStrategy()
    .WithConfigurationStore();

builder.Services.AddSingleton<ControlPlaneInMemoryRepository>();

builder.Services.AddScoped<IUserRepository>(serviceProvider =>
{
    var tenantAccessor = serviceProvider.GetRequiredService<IMultiTenantContextAccessor<AppTenantInfo>>();
    var tenant = tenantAccessor.MultiTenantContext?.TenantInfo
                 ?? throw new MultiTenantException("Tenant not resolved");
    
    var controlPlaneRepository = serviceProvider.GetRequiredService<ControlPlaneInMemoryRepository>();
    var dbRepoTenantConf = controlPlaneRepository.GetTenantConfiguration(tenant.Id ?? string.Empty);

    return dbRepoTenantConf switch
    {
        MongoDbConfiguration mongoDbConfig => new UserRepositoryMongoDb(tenantAccessor, mongoDbConfig),
        MySqlDbConfiguration mySqlDbConfig => new UserRepositoryMySql(tenantAccessor, mySqlDbConfig),
        _ => throw new MultiTenantException("ControlPlane database configuration does not match tenant preferred database type"),
    };
});


builder.Services.AddTransient<IUserService, UserService>();

var app = builder.Build();
app.UseMultiTenant();
app.UseFastEndpoints();
app.UseRouting();
app.Run();
