using Api.EFData.Helpers;
using Api.Infrastructure.Extensions;

using var host = Host
    .CreateDefaultBuilder(args)
    .ConfigureServices((builder, services) => services.AddPersistent(builder.HostingEnvironment))
    .UseConsoleLifetime()
    .Build();

await DatabaseHelper.MigrateAsync(host.Services);
