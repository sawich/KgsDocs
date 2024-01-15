using System.Text.Json.Serialization;

namespace Api.Infrastructure.Generators.Schemas;

public sealed class RootSchemaGenerator(Type modelType) : SchemaGenerator
{
    [JsonIgnore]
    public Type ModelType { get; } = modelType;
}
