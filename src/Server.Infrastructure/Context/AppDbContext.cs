using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Domain.Abstractions;
using Server.Domain.Entities;
using Server.Domain.Repositories;

namespace Server.Infrastructure.Context;

public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>, IUnitOfWork
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

        modelBuilder.Ignore<IdentityUserLogin<string>>();
        modelBuilder.Ignore<IdentityRoleClaim<string>>();
        modelBuilder.Ignore<IdentityUserClaim<string>>();
        modelBuilder.Ignore<IdentityUserToken<string>>();

        modelBuilder.Entity<Order>()
            .HasOne(o => o.AppUser)
            .WithMany(u => u.Orders)
            .HasForeignKey(o => o.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder
            .Entity<AppUser>(options =>
            {
                options.ToTable("Users");
            });

        modelBuilder
            .Entity<AppRole>(options =>
            {
                options.ToTable("Roles");
            });

        modelBuilder
            .Entity<IdentityUserRole<string>>(options =>
            {
                options.ToTable("UserRoles");
            });
    }


    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries<Entity>();

        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
                entry.Property(p => p.CreatedAt).CurrentValue = DateTime.Now;

            if (entry.State == EntityState.Modified)
                entry.Property(p => p.UpdatedAt).CurrentValue = DateTime.Now;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}
