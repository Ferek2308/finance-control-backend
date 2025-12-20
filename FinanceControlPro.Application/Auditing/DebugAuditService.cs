using FinanceControlPro.Domain.Enums;

namespace FinanceControlPro.Application.Auditing;

public class DebugAuditService
{
    private readonly IAuditService _auditService;

    public DebugAuditService(IAuditService auditService)
    {
        _auditService = auditService;
    }

    public async Task LogSystemStartupAsync(string ip, string userAgent)
    {
        await _auditService.LogAsync(new AuditLogRequest
        {
            Action = AuditAction.SYSTEM_STARTUP,
            Entity = AuditEntity.SYSTEM,
            Result = AuditResult.SUCCESS,
            Description = "Application started successfully",
            IpAddress = ip,
            UserAgent = userAgent
        });
    }
}
