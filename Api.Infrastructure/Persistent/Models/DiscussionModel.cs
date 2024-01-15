namespace Api.Infrastructure.Persistent.Models;

public sealed class DiscussionModel
{
    public int Id { get; init; }
    public string Text { get; init; } = string.Empty;
    public UserModel Author { get; init; } = UserModel.Empty;
    public DateTime PostedAt { get; init; } = DateTime.UtcNow;

    public DocumentModel Document { get; init; } = DocumentModel.Empty;

    internal static HistoryModel Empty => new();
}
