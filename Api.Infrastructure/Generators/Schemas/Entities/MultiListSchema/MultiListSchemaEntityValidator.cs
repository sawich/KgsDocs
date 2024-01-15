using Api.Infrastructure.Generators.Schemas.Validators.Abstractions;

namespace Api.Infrastructure.Generators.Schemas.Entities.MultiListSchema;

internal sealed record MultiListSchemaEntityValidator(IReadOnlyCollection<int> AvailableValues, bool IsRequired) : ISchemaEntityValidator
{
    public bool IsValid(object? userData)
    {
        if (userData is null)
            return false;

        if (userData is not int[] values)
            return false;

        if (IsRequired && values.Length <= 0)
            return false;

        if (values.All(value => AvailableValues.Any(e => e == value)) is false)
            return false;

        return true;
    }
}
