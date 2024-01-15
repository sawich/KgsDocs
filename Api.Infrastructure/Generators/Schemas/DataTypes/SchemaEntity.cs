using Api.Infrastructure.Generators.Schemas.Abstractions;
using Api.Infrastructure.Generators.Schemas.Entities.Abstractions;

namespace Api.Infrastructure.Generators.Schemas.DataTypes;

public sealed record SchemaEntity(ISchemaEntityRepresentative Representative, IParserSchemaEntity Parser);
