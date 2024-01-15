using Api.Infrastructure.Persistent;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Api.Infrastructure.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddPersistent(this IServiceCollection @this, IHostEnvironment env) => @this
            .AddDbContext<PersistentContext>(e => e
                .UseNpgsql("User ID=postgres;Host=postgres;Port=5432;Pooling=true", e => e
                    .EnableRetryOnFailure()
                    .MigrationsAssembly("Api.EFData"))
                .EnableSensitiveDataLogging(env.IsDevelopment())
                .EnableDetailedErrors(env.IsDevelopment()));
    }
}
