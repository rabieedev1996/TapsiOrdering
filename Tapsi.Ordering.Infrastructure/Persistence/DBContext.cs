using System.Text.RegularExpressions;
using Tapsi.Ordering.Domain.Entities.SQL;
using Tapsi.Ordering.Infrastructure.SQLRepositories;
using Tapsi.Ordering.Utility;
using Microsoft.EntityFrameworkCore;
using Tapsi.Ordering.Infrastructure.EntityConfigurations;


namespace Tapsi.Ordering.Infrastructure.Persistence;

public class Context:DbContext
{
    public Context(DbContextOptions<Context> options):base(options) {  }
    public DbSet<SQLSampleEntity> Sample { get; set; }
    public DbSet<Order> Order { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContext).Assembly);
        //
        // foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        // {
        //     if (typeof(EntityBase).IsAssignableFrom(entityType.ClrType))
        //     {
        //         modelBuilder.Entity(entityType.ClrType).Property(nameof(EntityBase.JalaliCreatedAt))
        //             .HasMaxLength(30);
        //
        //         modelBuilder.Entity(entityType.ClrType).Property(nameof(EntityBase.IsDeleted))
        //             .HasDefaultValue(false);
        //
        //     }
        // }
        // modelBuilder.ApplyConfiguration(new OrderConfig());

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var now = DateTime.Now;
        foreach (var entry in ChangeTracker.Entries<EntityBase>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.IsDeleted = false;
                    entry.Entity.CreateDatetime = now;
                    entry.Entity.JalaliCreatedAt = now.ToFa("yyyy/MM/dd");
                    entry.Entity.JalaliDateKey = int.Parse(now.ToFa("yyyyMMdd"));
                    break;
                case EntityState.Modified:
                    entry.Entity.ModifyDate = now;
                    break;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}