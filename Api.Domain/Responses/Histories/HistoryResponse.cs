namespace Api.Domain.Responses.Histories;

public sealed record HistoryResponse
{
    public int Id { get; set; }
    public UserResponse Author { get; set; } = UserResponse.Empty;
    public string Date { get; set; } = string.Empty;
}
