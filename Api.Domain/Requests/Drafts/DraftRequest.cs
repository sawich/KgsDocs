using System.Text.Json;

namespace Api.Domain.Requests.Drafts;

public sealed record DraftRequest(int Document, IReadOnlyList<JsonElement> Values);