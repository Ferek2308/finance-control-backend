using FinanceControlPro.Domain.Enums;

namespace FinanceControlPro.Application.Auditing;

public class AuditLogRequest
{
    public Guid? UserId { get; init; }
    public string? UserEmail { get; init; }

    public AuditAction Action { get; init; }
    public AuditEntity Entity { get; init; }
    public Guid? EntityId { get; init; }

    public AuditResult Result { get; init; }
    public string? Description { get; init; }

    public string? IpAddress { get; init; }
    public string? UserAgent { get; init; }
}
