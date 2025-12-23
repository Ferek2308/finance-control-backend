using FinanceControlPro.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceControlPro.Infrastructure.Persistence.Configurations;

public class AuditLogConfiguration : IEntityTypeConfiguration<AuditLog>
{
    public void Configure(EntityTypeBuilder<AuditLog> builder)
    {
        builder.ToTable("audit_logs");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnName("id")
            .ValueGeneratedNever();

        builder.Property(a => a.UserId)
            .HasColumnName("user_id");

        builder.Property(a => a.UserEmail)
            .HasColumnName("user_email")
            .HasMaxLength(255);

        builder.Property(a => a.Action)
            .HasColumnName("action")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(a => a.Entity)
            .HasColumnName("entity")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(a => a.EntityId)
            .HasColumnName("entity_id");

        builder.Property(a => a.Description)
            .HasColumnName("description");

        builder.Property(a => a.Result)
            .HasColumnName("result")
            .HasConversion<string>()
            .IsRequired();

        builder.Property(a => a.IpAddress)
            .HasColumnName("ip_address")
            .HasMaxLength(45);

        builder.Property(a => a.UserAgent)
            .HasColumnName("user_agent");

        builder.Property(a => a.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();

        builder.HasIndex(a => a.UserId);
        builder.HasIndex(a => a.Action);
        builder.HasIndex(a => a.Entity);
        builder.HasIndex(a => a.CreatedAt);
    }
}
