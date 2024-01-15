using Api.Infrastructure.Generators.Schemas.Validators;
using Api.Infrastructure.Generators.Schemas.Validators.Abstractions;
using System.Reflection;

namespace Api.Infrastructure.Generators.Schemas.Entities.Abstractions;

public interface IEditableSchemaEntity
{
    bool IsRequired { get; }

    PropertyInfo Property { get; }

    // IDataSchemaValidator GetValidator() => throw new Exception();
    IDataSchemaValidator GetValidator() => new AlwaysTrueSchemaValidator();
}
