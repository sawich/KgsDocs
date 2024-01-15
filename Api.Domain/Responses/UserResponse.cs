namespace Api.Domain.Responses;

public sealed record UserResponse
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    internal static UserResponse Empty => new();
}
