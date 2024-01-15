namespace Api.App.Requests;

public sealed record GetDiscussionRequest(int Document, int Limit = 100, int Offset = 0);
