using Api.Infrastructure.Generators.Schemas.Enums;

namespace Api.Infrastructure.Generators.Schemas.Entities.Abstractions;

public interface ISchemaEntityRepresentative
{
    SchemaEntityVariant Entity { get; }
    string Label { get; }
}
