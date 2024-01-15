using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;

namespace Api.Infrastructure.Generators.Schemas.Entities.TextLine;

public sealed record TextLineSchemaEntity(string Label, int MinLength, int MaxLength, bool IsRequired) : ISchemaEntityRepresentative, IEditableSchemaEntity
{
    #region IParentSchemaEntity

    public SchemaEntityVariant Entity { get; } = SchemaEntityVariant.TextLine;

    #endregion IParentSchemaEntity
}
