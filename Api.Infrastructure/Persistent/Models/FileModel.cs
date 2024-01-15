namespace Api.Infrastructure.Persistent.Models;

public sealed class FileModel
{
    public int Id { get; }
    public string Name { get; } = string.Empty;
    public string Path { get; } = string.Empty;

    internal static FileModel Empty => new();
}
