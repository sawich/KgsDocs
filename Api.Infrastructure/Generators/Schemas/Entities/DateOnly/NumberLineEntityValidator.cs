using Api.Infrastructure.Generators.Schemas.Validators.Abstractions;

namespace Api.Infrastructure.Generators.Schemas.Entities.DateOnly;

internal sealed record DateOnlyEntityValidator(System.DateOnly? Min, System.DateOnly? Max, bool IsRequired) : ISchemaEntityValidator
{
    public bool IsValid(object? userData)
    {
        if (userData is null)
            return false;

        if (userData is not System.DateOnly)
            return false;

        // min
        // max

        return true;
    }
}
