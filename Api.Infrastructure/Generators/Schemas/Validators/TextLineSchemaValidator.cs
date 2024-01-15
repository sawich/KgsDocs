using Api.Infrastructure.Generators.Schemas.Enums;
using Api.Infrastructure.Generators.Schemas.Validators.Abstractions;

namespace Api.Infrastructure.Generators.Schemas.Validators;

public sealed class ValidatorException(int order, string message) : Exception(message)
{
    public int Order { get; } = order;
}

internal sealed record AlwaysTrueSchemaValidator : IDataSchemaValidator
{
    public void Validate(object userData, int order)
    {
        // 
    }
}

internal sealed record ListSchemaValidator : IDataSchemaValidator
{
    public void Validate(object userData, int order)
    {
        throw new ValidatorException(0, "NotImplementedException");
    }
}

internal sealed record TextBoxSchemaValidator(int MaxLength, bool IsRequired) : IDataSchemaValidator
{
    public void Validate(object userData, int order)
    {
        // throw new ValidatorException(0, "NotImplementedException");
    }
}

internal sealed record TextLineSchemaValidator(TextLineType Type, int MaxLength, bool IsRequired) : IDataSchemaValidator
{
    public void Validate(object userData, int order)
    {
        // throw new ValidatorException(0, "NotImplementedException");
    }
}

internal sealed record NumberLineSchemaValidator : IDataSchemaValidator
{
    public void Validate(object userData, int order)
    {
        if (userData is not int)
            throw new ValidatorException(order, "Неверный тип данных");
    }
}

internal sealed record DateOnlySchemaValidator : IDataSchemaValidator
{
    public void Validate(object userData, int order)
    {
        if (userData is not string data)
            throw new ValidatorException(order, "Неверный тип данных");

        if (DateOnly.TryParse(data, out var _))
            throw new ValidatorException(order, "Неверный формат даты");
    }
}

internal sealed record FileUploadSchemaValidator : IDataSchemaValidator
{
    public void Validate(object userData, int order)
    {
        throw new ValidatorException(0, "NotImplementedException");
    }
}
;