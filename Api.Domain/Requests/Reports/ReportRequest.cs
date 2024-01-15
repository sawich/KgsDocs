using Api.Domain.Enums;

namespace Api.Domain.Requests.Reports;

public sealed record ReportRequest(MailType Type, DateOnly BeginAt, DateOnly EndAt);
