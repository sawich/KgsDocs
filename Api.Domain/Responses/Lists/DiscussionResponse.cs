using Api.Domain.Responses;

namespace Api.Infrastructure.Mapper;

public sealed record DiscussionResponse(int Id, string Text, UserResponse Author, string PostedAt);
