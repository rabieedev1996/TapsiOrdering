using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tapsi.Ordering.Domain.Entities.SQL;

namespace Tapsi.Ordering.Infrastructure.EntityConfigurations;

public class OrderConfig :IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(s => s.CustomerName).HasMaxLength(300);
        builder.Property(s => s.TotalPrice).HasColumnType("decimal(18,2)");
    }
}