using Api.Infrastructure.Generators.Schemas.Validators.Abstractions;

namespace Api.Infrastructure.Generators.Schemas.Entities.ListSchema;

internal sealed record ListSchemaEntityValidator(IReadOnlyCollection<int> AvailableValues, bool IsRequired) : ISchemaEntityValidator
{
    public bool IsValid(object? userData)
    {
        if (userData is null)
            return false;

        if (userData is not int value)
            return false;

        if (IsRequired && value <= 0)
            return false;

        if (AvailableValues.Any(e => e == value) is false)
            return false;

        return true;
    }
}
