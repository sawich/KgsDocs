using Api.Infrastructure.Generators.Schemas.Entities;
using Api.Infrastructure.Generators.Schemas.Enums;
using System.Reflection;

namespace Api.Infrastructure.Generators.Schemas;

public class SchemaGenerator
{
    public ICollection<object> Entities { get; set; } = new List<object>();

    public SchemaGenerator AddList(PropertyInfo property, string name, SourceListEntity source, bool multi = false)
    {
        Entities.Add(new ListSchemaEntity(property, name, source, multi));
        return this;
    }
    
    public SchemaGenerator AddTextBox(PropertyInfo property, string label, int maxLength = 1024)
    {
        Entities.Add(new TextBoxSchemaEntity(property, label, maxLength));
        return this;
    }
    
    public SchemaGenerator AddTextLine(PropertyInfo property, string label, int maxLength = 256, bool isRequired = false)
    {
        Entities.Add(new TextLineSchemaEntity(property, label, TextLineType.Text, maxLength, isRequired));
        return this;
    }

    public SchemaGenerator AddNuberLine(PropertyInfo property, string label, int maxLength = 256, bool isRequired = false)
    {
        Entities.Add(new TextLineSchemaEntity(property, label, TextLineType.Number, maxLength, isRequired));
        return this;
    }

    public SchemaGenerator AddDateOnly(PropertyInfo property, string label)
    {
        Entities.Add(new DateOnlySchemaEntity(property, label));
        return this;
    }

    public SchemaGenerator AddFile(PropertyInfo property, string name, SourceFileEntity source, int maxSizeInBytesPerFile = 1024, bool multi = false)
    {
        Entities.Add(new FileUploadSchemaEntity(property, name, source, maxSizeInBytesPerFile, multi));
        return this;
    }

    public SchemaGenerator AddPanel(Action<PanelSchemaEntity> callable, string? name = null)
    {
        var panel = new PanelSchemaEntity(name ?? string.Empty);
        callable(panel);

        Entities.Add(panel);

        return this;
    }
}
