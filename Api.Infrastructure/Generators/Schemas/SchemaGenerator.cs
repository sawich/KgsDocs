using Api.Infrastructure.Generators.Schemas.Abstractions;
using Api.Infrastructure.Generators.Schemas.DataTypes;
using Api.Infrastructure.Generators.Schemas.Entities;
using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;
using Api.Infrastructure.Generators.Schemas.Entities.DateOnly;
using Api.Infrastructure.Generators.Schemas.Entities.ListSchema;
using Api.Infrastructure.Generators.Schemas.Entities.MultiListSchema;
using Api.Infrastructure.Generators.Schemas.Entities.NumberLine;
using Api.Infrastructure.Generators.Schemas.Entities.TextBox;
using Api.Infrastructure.Generators.Schemas.Entities.TextLine;
using Api.Infrastructure.Persistent.Models.Abstractions;
using System.Reflection;

namespace Api.Infrastructure.Generators.Schemas;

public sealed class SchemaGenerator(Type model)
{
    private readonly List<ISchemaEntityRepresentative> _representatives = [];
    private readonly List<IParserSchemaEntity> _parsers = [];

    public IReadOnlyList<ISchemaEntityRepresentative> BuildRepresentatives() => _representatives;
    public SchemaEntityParser BuildParsers() => new(model, _parsers);

    public SchemaGenerator AddList<TSource>(string propertyName, IQueryable<TSource> source, string label, bool multi = false, bool isRequired = true) where TSource : notnull, IListPersistentModel
    {
        if (multi)
        {
            _representatives.Add(new ListSchemaEntity(label, source.Select(e => e.Name).ToArray(), isRequired));

            var validator = new MultiListSchemaEntityValidator(source.Select(e => e.Id).ToArray(), isRequired);
            var parser = new ParserSchemaEntity<int[]>(GetProperty(propertyName), validator, label);

            _parsers.Add(parser);
        }
        else
        {
            _representatives.Add(new MultiListSchemaEntity(label, source.Select(e => e.Name).ToArray(), isRequired));

            var validator = new ListSchemaEntityValidator(source.Select(e => e.Id).ToArray(), isRequired);
            var parser = new ParserSchemaEntity<int>(GetProperty(propertyName), validator, label);

            _parsers.Add(parser);
        }

        return this;
    }

    public SchemaGenerator AddTextBox(string propertyName, string label, int minLength = 0, int maxLength = 1024, bool isRequired = true)
    {
        _representatives.Add(new TextBoxSchemaEntity(label, minLength, maxLength, isRequired));

        var validator = new TextBoxEntityValidator(minLength, maxLength, isRequired);
        var parser = new ParserSchemaEntity<string>(GetProperty(propertyName), validator, label);

        _parsers.Add(parser);

        return this;
    }

    public SchemaGenerator AddTextLine(string propertyName, string label, int minLength = 0, int maxLength = 256, bool isRequired = true)
    {
        _representatives.Add(new TextLineSchemaEntity(label, minLength, maxLength, isRequired));

        var validator = new TextBoxEntityValidator(minLength, maxLength, isRequired);
        var parser = new ParserSchemaEntity<string>(GetProperty(propertyName), validator, label);

        _parsers.Add(parser);

        return this;
    }

    public SchemaGenerator AddNumberLine(string propertyName, string label, int minLength = 0, int maxLength = 256, bool isRequired = true)
    {
        _representatives.Add(new NumberLineSchemaEntity(label, minLength, maxLength, isRequired));

        var validator = new NumberLineEntityValidator(minLength, maxLength, isRequired);
        var parser = new ParserSchemaEntity<int>(GetProperty(propertyName), validator, label);

        _parsers.Add(parser);

        return this;
    }

    public SchemaGenerator AddDateOnly(string propertyName, string label, DateOnly? min = null, DateOnly? max = null, bool isRequired = true)
    {
        _representatives.Add(new DateOnlySchemaEntity(label, isRequired));

        var validator = new DateOnlyEntityValidator(min, max, isRequired);
        var parser = new ParserSchemaEntity<int>(GetProperty(propertyName), validator, label);

        _parsers.Add(parser);

        return this;
    }

    //public SchemaGenerator AddFile(string propertyName, string label, SourceFileEntity source, int maxSizeInBytesPerFile = 1024, bool multi = false)
    //{
    //    Entities.Add(new FileUploadSchemaEntity(property, label, source, maxSizeInBytesPerFile, multi));
    //    return this;
    //}

    public SchemaGenerator AddPanel(Action<SchemaGenerator> callable, string label = "")
    {
        var generator = new SchemaGenerator(model);
        callable(generator);

        _representatives.Add(new PanelSchemaEntity(generator.BuildRepresentatives(), label));
        _parsers.AddRange(generator.BuildParsers().Parsers);

        return this;
    }

    private PropertyInfo GetProperty(string name)
    {
        var property = model.GetProperty(name);
        ArgumentNullException.ThrowIfNull(property);

        return property;
    }
}
