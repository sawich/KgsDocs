namespace Api.App.Requests;

public sealed record PostFileRequest
{
    public int Id { get; set; }
    public IFormFile File { get; set; } = new FormFile(Stream.Null, 0, 0, "", "");
}
