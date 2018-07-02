
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Model.OrderAggregate;

namespace Ordering.Infrastructure.Mappings
{
	public class OrderItemMap : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> orderItemConfiguration)
		{
			orderItemConfiguration.ToTable("orderItems", OrderingContext.DEFAULT_SCHEMA);

			orderItemConfiguration.HasKey(oi => oi.Id);

			orderItemConfiguration.Property(oi => oi.Quantity).IsRequired();

			orderItemConfiguration.Property(oi => oi.Product).IsRequired();
			orderItemConfiguration.Property(oi => oi.Order).IsRequired();
		}
	}
}