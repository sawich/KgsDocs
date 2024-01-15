using Api.Domain.Enums;

namespace Api.Domain.Responses.Lists;

public sealed record MailTypeResponse(MailType Type, string Name);
