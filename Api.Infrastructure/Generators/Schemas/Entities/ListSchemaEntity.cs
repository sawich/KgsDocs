using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Api.Infrastructure.Generators.Schemas.Entities;

public sealed record ListSchemaEntity([property: JsonIgnore] PropertyInfo Property, string Label, SourceListEntity Source, bool Multi = false, bool IsRequired = false) : IParentSchemaEntity, IEditableSchemaEntity
{
    #region IParentSchemaEntity

    public SchemaEntity Entity { get; } = SchemaEntity.List;

    #endregion IParentSchemaEntity
}
