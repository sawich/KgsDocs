using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Api.Infrastructure.Generators.Schemas.Entities;

public sealed record FileUploadSchemaEntity([property: JsonIgnore] PropertyInfo Property, string Label, SourceFileEntity Source, int MaxSizeInBytesPerFile = 1024, bool Multi = false, bool IsRequired = false) : IParentSchemaEntity, IEditableSchemaEntity
{
    #region IParentSchemaEntity

    public SchemaEntity Entity { get; } = SchemaEntity.File;

    #endregion IParentSchemaEntity
}
