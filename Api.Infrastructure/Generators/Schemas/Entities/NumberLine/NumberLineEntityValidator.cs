using Api.Infrastructure.Generators.Schemas.Validators.Abstractions;

namespace Api.Infrastructure.Generators.Schemas.Entities.NumberLine;

internal sealed record NumberLineEntityValidator(int MinLength, int MaxLength, bool IsRequired) : ISchemaEntityValidator
{
    public bool IsValid(object? userData)
    {
        if (userData is null)
            return false;

        if (userData is not string value)
            return false;

        if (value.Length < MaxLength)
            return false;

        if (value.Length > MinLength)
            return false;

        if (IsRequired && value.Length <= 0)
            return false;

        return true;
    }
}
