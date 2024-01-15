using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Enums;

namespace Api.Infrastructure.Generators.Schemas.Entities;

public class PanelSchemaEntity(string name) : SchemaGenerator, IParentSchemaEntity
{
    #region IParentSchemaEntity

    public SchemaEntity Entity { get; } = SchemaEntity.TextLine;

    #endregion IParentSchemaEntity

    public string Label { get; } = name;
}
