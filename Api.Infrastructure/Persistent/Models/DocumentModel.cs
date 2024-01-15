using Api.Domain.Enums;

namespace Api.Infrastructure.Persistent.Models;

public sealed class DocumentModel
{
    public int Id { get; }

    public DocumentState State { get; set; }
    public UserModel Author { get; } = UserModel.Empty;
    public ICollection<UserModel> Recipients { get; } = Array.Empty<UserModel>();
    public DateOnly SentAt { get; }

    internal static DocumentModel Empty => new();
}
