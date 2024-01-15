using Api.Infrastructure.Generators.Schemas;

namespace Api.App.DataTypes;

public sealed record SchemaCatalogEntity(string Name, IReadOnlyList<object> Entities);
