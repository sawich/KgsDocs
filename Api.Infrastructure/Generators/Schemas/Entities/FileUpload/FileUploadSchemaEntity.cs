using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Api.Infrastructure.Generators.Schemas.Entities.FileUpload;

public sealed record FileUploadSchemaEntity([property: JsonIgnore] PropertyInfo Property, string Label, SourceFileEntity Source, bool IsRequired, int MaxSizeInBytesPerFile = 1024, bool Multi = false) : ISchemaEntityRepresentative, IEditableSchemaEntity
{
    #region IParentSchemaEntity

    public SchemaEntityVariant Entity { get; } = SchemaEntityVariant.File;

    #endregion IParentSchemaEntity
}
