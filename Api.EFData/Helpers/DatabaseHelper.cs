using Api.Infrastructure.Persistent;
using Microsoft.EntityFrameworkCore;

namespace Api.EFData.Helpers;

internal static class DatabaseHelper
{
    internal static async ValueTask MigrateAsync(IServiceProvider provider, CancellationToken ct = default)
    {
        await using var scope = provider.CreateAsyncScope();
        await using var context = scope.ServiceProvider.GetRequiredService<PersistentContext>();

        await context.Database.MigrateAsync(ct);
    }
}
