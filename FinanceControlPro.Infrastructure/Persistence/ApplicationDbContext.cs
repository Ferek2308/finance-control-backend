using Microsoft.EntityFrameworkCore;
using FinanceControlPro.Domain.Entities;

namespace FinanceControlPro.Infrastructure.Persistence

{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Aquí irán los DbSet<> cuando se definan las entidades.

          public DbSet<AuditLog> AuditLogs { get; set; }

          protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }


            public async Task<bool> CanConnectAsync()
        {
            return await Database.CanConnectAsync();
        }
    }
}
