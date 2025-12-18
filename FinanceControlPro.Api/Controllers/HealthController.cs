using FinanceControlPro.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace FinanceControlPro.Api.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public HealthController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet("db")]
    public async Task<IActionResult> CheckDatabase()
    {
         try
    {
        var canConnect = await _dbContext.Database.CanConnectAsync();

        return Ok("Conexión a la base de datos OK");
    }
    catch (Exception ex)
    {
        return StatusCode(500, ex.ToString());
    }
    }
}
