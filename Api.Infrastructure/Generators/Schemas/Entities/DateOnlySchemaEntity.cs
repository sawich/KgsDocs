using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Api.Infrastructure.Generators.Schemas.Entities;

public sealed record DateOnlySchemaEntity([property: JsonIgnore] PropertyInfo Property, string Label, bool IsRequired = false) : IParentSchemaEntity, IEditableSchemaEntity
{
    #region IParentSchemaEntity

    public SchemaEntity Entity { get; } = SchemaEntity.DateOnly;

    #endregion IParentSchemaEntity
}