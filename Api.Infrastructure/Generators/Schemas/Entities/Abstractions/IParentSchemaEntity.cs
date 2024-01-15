using Api.Infrastructure.Generators.Schemas.Enums;

namespace Api.Infrastructure.Generators.Schemas.Entities.Abstractions;

public interface IParentSchemaEntity
{
    SchemaEntity Entity { get; }
    string Label { get; }
}
