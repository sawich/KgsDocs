namespace Api.Infrastructure.Generators.Schemas.Validators.Abstractions;

public interface ISchemaEntityValidator
{
    bool IsValid(object? userData);
}
