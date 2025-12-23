using FinanceControlPro.Domain.Entities;


namespace FinanceControlPro.Application.Auditing;

public class AuditService : IAuditService
{

private readonly IAuditLogRepository _repository;

    public AuditService(IAuditLogRepository repository)
    {
        _repository = repository;
    }

    public async Task LogAsync(AuditLogRequest request)
    {
        var auditLog = new AuditLog(
            request.UserId,
            request.UserEmail,
            request.Action,
            request.Entity,
            request.Result,
            request.EntityId,
            request.Description,
            request.IpAddress,
            request.UserAgent
        );

 

         await _repository.AddAsync(auditLog);
    }
}
