using FinanceControlPro.Domain.Entities;
using FinanceControlPro.Application.Auditing;

namespace FinanceControlPro.Infrastructure.Persistence.Repositories;

public class AuditLogRepository :  IAuditLogRepository
{
    private readonly ApplicationDbContext _context;

    public AuditLogRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(AuditLog auditLog)
    {
        _context.AuditLogs.Add(auditLog);
        await _context.SaveChangesAsync();
    }
}
