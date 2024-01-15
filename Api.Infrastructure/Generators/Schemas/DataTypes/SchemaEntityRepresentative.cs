using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;

namespace Api.Infrastructure.Generators.Schemas.DataTypes;

public sealed record SchemaEntityRepresentative<T>(T Value) where T : ISchemaEntityRepresentative;
