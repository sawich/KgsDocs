namespace Api.Infrastructure.Generators.Schemas.Validators.Abstractions;

public interface IDataSchemaValidator
{
    void Validate(object userData, int order);
}
