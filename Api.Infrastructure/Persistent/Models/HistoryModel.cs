using Api.Domain.Enums;

namespace Api.Infrastructure.Persistent.Models;

public sealed class HistoryModel
{
    public int Id { get; }
    public UserModel Author { get; } = UserModel.Empty;
    public DateOnly SentAt { get; }

    public DocumentModel Document { get; } = DocumentModel.Empty;

    internal static HistoryModel Empty => new();
}
