namespace FinanceControlPro.Application.Auditing;

public interface IAuditService
{
    Task LogAsync(AuditLogRequest request);
}
