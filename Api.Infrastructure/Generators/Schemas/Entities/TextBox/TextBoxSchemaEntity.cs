using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;

namespace Api.Infrastructure.Generators.Schemas.Entities.TextBox;

public sealed record TextBoxSchemaEntity(string Label, int MinLength, int MaxLength, bool IsRequired) : ISchemaEntityRepresentative, IEditableSchemaEntity
{
    #region IParentSchemaEntity

    public SchemaEntityVariant Entity { get; } = SchemaEntityVariant.TextBox;

    #endregion IParentSchemaEntity
}
