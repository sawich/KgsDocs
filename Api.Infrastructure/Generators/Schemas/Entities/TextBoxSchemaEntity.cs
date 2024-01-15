using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;
using Api.Infrastructure.Generators.Schemas.Validators.Abstractions;
using Api.Infrastructure.Generators.Schemas.Validators;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Api.Infrastructure.Generators.Schemas.Entities;

public sealed record TextBoxSchemaEntity([property: JsonIgnore] PropertyInfo Property, string Label, int MaxLength, bool IsRequired = false) : IParentSchemaEntity, IEditableSchemaEntity
{
    #region IParentSchemaEntity

    public SchemaEntity Entity { get; } = SchemaEntity.TextBox;

    #endregion IParentSchemaEntity

    #region IEditableSchemaEntity

    public IDataSchemaValidator GetValidator() => new TextBoxSchemaValidator(MaxLength, IsRequired);

    #endregion IEditableSchemaEntity
}
