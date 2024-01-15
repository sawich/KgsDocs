using Api.Domain.Enums;

namespace Api.Domain.Responses.Tasks;

public sealed record TaskResponse
{
    public int Id { get; }
    public int Type { get; }
    public UserResponse Author { get; } = UserResponse.Empty;
    public TaskState State { get; set; }
    public string Until { get; } = string.Empty;
}
