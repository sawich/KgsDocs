using Api.Infrastructure.Generators.Schemas.Abstractions;
using Api.Infrastructure.Generators.Schemas.Validators;
using Api.Infrastructure.Generators.Schemas.Validators.Abstractions;
using System.Reflection;
using System.Text.Json;

namespace Api.Infrastructure.Generators.Schemas;

public sealed record ParserSchemaEntity<T>(PropertyInfo Property, ISchemaEntityValidator Validator, string Label) : IParserSchemaEntity where T : notnull
{
    public void SetValue(object instance, JsonElement element)
    {
        var value = element.Deserialize<T>();

        if (Validator.IsValid(value) is false)
            throw new ValidatorException(Label);

        Property.SetValue(instance, value);
    }
}
