using Api.EFData.Helpers;
using Api.Infrastructure.Extensions;
using Api.Infrastructure.Persistent.Models;
using Api.Infrastructure.Persistent;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

using var host = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((builder, services) =>
    {
        services.AddPersistent(builder.HostingEnvironment);

        services
            .AddAuthorization()
            .AddIdentityApiEndpoints<UserModel>()
            .AddEntityFrameworkStores<PersistentContext>();
        })
        .UseConsoleLifetime()
        .Build();

await DatabaseHelper.MigrateAsync(host.Services);
