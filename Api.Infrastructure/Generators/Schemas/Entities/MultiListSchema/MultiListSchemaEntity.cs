using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;

namespace Api.Infrastructure.Generators.Schemas.Entities.MultiListSchema;

public sealed record MultiListSchemaEntity(string Label, IReadOnlyCollection<string> Values, bool IsRequired) : ISchemaEntityRepresentative, IEditableSchemaEntity
{
    #region IParentSchemaEntity

    public SchemaEntityVariant Entity { get; } = SchemaEntityVariant.MultiList;

    #endregion IParentSchemaEntity
}
