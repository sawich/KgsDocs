using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;

namespace Api.Infrastructure.Generators.Schemas.Entities;

public sealed record PanelSchemaEntity(IReadOnlyList<object> Entities, string Label) : ISchemaEntityRepresentative
{
    #region IParentSchemaEntity

    public SchemaEntityVariant Entity { get; } = SchemaEntityVariant.Panel;

    #endregion IParentSchemaEntity
}
