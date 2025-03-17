using AuthService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Tenant.Domain;

namespace Tenant.Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    // Tabelas do banco (DbSet)
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<RoleUserEntity> RoleUsers { get; set; }
    public DbSet<RefreshTokenEntity> RefreshTokens { get; set; }
    public DbSet<PasswordResetTokenEntity> PasswordResets { get; set; }
    public DbSet<UserSessionEntity> UserSessions { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configurar nomes das tabelas, caso necessário
        modelBuilder.Entity<UserEntity>().ToTable("users");
        modelBuilder.Entity<RoleEntity>().ToTable("roles");
        modelBuilder.Entity<RoleUserEntity>().ToTable("role_users");
        modelBuilder.Entity<RefreshTokenEntity>().ToTable("refresh_tokens");
        modelBuilder.Entity<PasswordResetTokenEntity>().ToTable("password_reset_tokens");
        modelBuilder.Entity<UserSessionEntity>().ToTable("user_sessions");
    }
    
    public override int SaveChanges()
    {
        AtualizarCamposCoreEntity();
        return base.SaveChanges();
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        AtualizarCamposCoreEntity();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private void AtualizarCamposCoreEntity()
    {
        var now = DateTime.UtcNow;
        
        foreach (var entry in ChangeTracker.Entries<CoreEntity>())
        {
            if (entry.State == EntityState.Added)
            {
                entry.Entity.InsertDate = now;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Entity.UpdateDate = now;
            }
        }
    }
}