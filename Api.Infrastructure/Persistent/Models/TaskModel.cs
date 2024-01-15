using Api.Domain.Enums;

namespace Api.Infrastructure.Persistent.Models;

public sealed class TaskModel
{
    public int Id { get; }
    public int Type { get; }
    public UserModel Author { get; } = UserModel.Empty;
    public TaskState State { get; set; }
    public DateOnly Until { get; }

    internal static TaskModel Empty => new();
}
