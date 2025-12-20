using FinanceControlPro.Application.Auditing;
using FinanceControlPro.Domain.Enums;
using System.Security.Claims;

namespace FinanceControlPro.API.Middlewares;

public class AuditMiddleware
{
    private readonly RequestDelegate _next;

    public AuditMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IAuditService auditService)
    {
        try
        {
            await _next(context);

            // Solo se auditan respuestas críticas aquí (401 / 403)
            if (context.Response.StatusCode == StatusCodes.Status401Unauthorized ||
                context.Response.StatusCode == StatusCodes.Status403Forbidden)
            {
                await auditService.LogAsync(new AuditLogRequest
                {
                    Action = AuditAction.UNAUTHORIZED_ACCESS,
                    Entity = AuditEntity.SYSTEM,
                    Result = AuditResult.FAILURE,
                    IpAddress = context.Connection.RemoteIpAddress?.ToString(),
                    UserAgent = context.Request.Headers["User-Agent"].ToString()
                });
            }
        }
        catch
        {
            throw;
        }
    }
}
