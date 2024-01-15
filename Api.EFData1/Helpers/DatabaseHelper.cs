using Api.Infrastructure.Persistent;
using Api.Infrastructure.Persistent.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.EFData.Helpers;

internal static class DatabaseHelper
{
    internal static async ValueTask MigrateAsync(IServiceProvider provider, CancellationToken ct = default)
    {
        await using var scope = provider.CreateAsyncScope();
        await using var context = scope.ServiceProvider.GetRequiredService<PersistentContext>();

        await context.Database.MigrateAsync(ct);

        var manager = scope.ServiceProvider.GetRequiredService<UserManager<UserModel>>();
        var user = manager.FindByNameAsync("sawich");
        if (user is null) 
        {
            await manager.CreateAsync(new UserModel
            {
                UserName = "sawich",
            }, "qwe123");
        }
    }
}
