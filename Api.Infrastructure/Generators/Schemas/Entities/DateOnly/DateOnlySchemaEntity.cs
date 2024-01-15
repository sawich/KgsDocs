using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;

namespace Api.Infrastructure.Generators.Schemas.Entities.DateOnly;

public sealed record DateOnlySchemaEntity(string Label, bool IsRequired) : ISchemaEntityRepresentative, IEditableSchemaEntity
{
    #region IParentSchemaEntity

    public SchemaEntityVariant Entity { get; } = SchemaEntityVariant.DateOnly;

    #endregion IParentSchemaEntity
}