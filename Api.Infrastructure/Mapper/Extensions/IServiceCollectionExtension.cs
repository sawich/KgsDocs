using Microsoft.Extensions.DependencyInjection;

namespace Api.Infrastructure.Mapper.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddMapper(this IServiceCollection @this)
    {
        @this.AddAutoMapper(e =>
        {
            e.AddProfile<ProfileMapperResponse>();
        });

        return @this;
    }
}
