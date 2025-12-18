using Microsoft.EntityFrameworkCore;

namespace FinanceControlPro.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Aquí irán los DbSet<> cuando se definan las entidades.

            public async Task<bool> CanConnectAsync()
        {
            return await Database.CanConnectAsync();
        }
    }
}
