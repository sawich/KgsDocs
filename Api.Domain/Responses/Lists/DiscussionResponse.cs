using Api.Domain.Responses;

namespace Api.Domain.Responses.Lists;

public sealed record DiscussionResponse(int Id, string Text, UserResponse Author, string PostedAt);
