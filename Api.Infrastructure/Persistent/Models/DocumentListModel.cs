using Api.Infrastructure.Persistent.Models.Abstractions;

namespace Api.Infrastructure.Persistent.Models;

public sealed class DocumentListModel : IListPersistentModel
{
    public int Id { get; }
    public string Name { get; init; } = string.Empty;

    internal static DocumentListModel Empty => new();
}
