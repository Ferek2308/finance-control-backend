using FinanceControlPro.Domain.Entities;

namespace FinanceControlPro.Application.Auditing;

public interface IAuditLogRepository
{
    Task AddAsync(AuditLog auditLog);
}
