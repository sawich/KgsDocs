namespace Api.Infrastructure.Generators.Schemas;

public static class SchemaDocumentGenerator
{
    public static RootSchemaGenerator CreateSchema(Type modelType) => new(modelType);
}
