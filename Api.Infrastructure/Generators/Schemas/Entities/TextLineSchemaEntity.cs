using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;
using Api.Infrastructure.Generators.Schemas.Validators;
using Api.Infrastructure.Generators.Schemas.Validators.Abstractions;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Api.Infrastructure.Generators.Schemas.Entities;

public sealed record TextLineSchemaEntity([property: JsonIgnore] PropertyInfo Property, string Label, TextLineType Type, int MaxLength, bool IsRequired) : IParentSchemaEntity, IEditableSchemaEntity
{
    #region IParentSchemaEntity
    
    public SchemaEntity Entity { get; } = SchemaEntity.TextLine;

    #endregion IParentSchemaEntity

    #region IEditableSchemaEntity

    public IDataSchemaValidator GetValidator() => new TextLineSchemaValidator(Type, MaxLength, IsRequired);

    #endregion IEditableSchemaEntity
}
