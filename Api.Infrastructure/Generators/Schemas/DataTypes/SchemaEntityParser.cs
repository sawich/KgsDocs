using Api.Infrastructure.Generators.Schemas.Abstractions;

namespace Api.Infrastructure.Generators.Schemas.DataTypes;

public sealed record SchemaEntityParser(Type Model, IReadOnlyList<IParserSchemaEntity> Parsers);
