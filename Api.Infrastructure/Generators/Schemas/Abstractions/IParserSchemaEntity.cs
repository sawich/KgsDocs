using System.Text.Json;

namespace Api.Infrastructure.Generators.Schemas.Abstractions;

public interface IParserSchemaEntity
{
    void SetValue(object instance, JsonElement element);
}
