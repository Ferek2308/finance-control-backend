using FinanceControlPro.Domain.Enums;

namespace FinanceControlPro.Domain.Entities;

public class AuditLog
{
    public Guid Id { get; private set; }

    public Guid? UserId { get; private set; }
    public string? UserEmail { get; private set; }

    public AuditAction Action { get; private set; }
    public AuditEntity Entity { get; private set; }
    public Guid? EntityId { get; private set; }

    public string? Description { get; private set; }
    public AuditResult Result { get; private set; }

    public string? IpAddress { get; private set; }
    public string? UserAgent { get; private set; }

    public DateTime CreatedAt { get; private set; }

    private AuditLog() { }

    public AuditLog(
        Guid? userId,
        string? userEmail,
        AuditAction action,
        AuditEntity entity,
        AuditResult result,
        Guid? entityId = null,
        string? description = null,
        string? ipAddress = null,
        string? userAgent = null
    )
    {
        Id = Guid.NewGuid();
        UserId = userId;
        UserEmail = userEmail;
        Action = action;
        Entity = entity;
        Result = result;
        EntityId = entityId;
        Description = description;
        IpAddress = ipAddress;
        UserAgent = userAgent;
        CreatedAt = DateTime.UtcNow;
    }
}
