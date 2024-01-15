using Api.Domain.Enums;

namespace Api.Infrastructure.Persistent.Models;

public sealed class FamiliarizationModel
{
    public int Id { get; }
    public FamiliarizationState State { get; set; }
    public UserModel Author { get; } = UserModel.Empty;
    public UserModel Inspector { get; } = UserModel.Empty;
    public DateOnly SentAt { get; }

    internal static FamiliarizationModel Empty => new();
}
