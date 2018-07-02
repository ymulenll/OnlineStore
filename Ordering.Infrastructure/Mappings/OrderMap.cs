
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Model.CustomerAggregate;
using Ordering.Domain.Model.OrderAggregate;

namespace Ordering.Infrastructure.Mappings
{
	public class OrderMap : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> orderConfiguration)
		{
			orderConfiguration.ToTable("orders", OrderingContext.DEFAULT_SCHEMA);

			orderConfiguration.HasKey(o => o.Id);

			var navigation = orderConfiguration.Metadata.FindNavigation(nameof(Order.OrderItems));
			navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

			orderConfiguration.HasOne<Customer>("Buyer")
				.WithMany()
				.IsRequired()
				.HasForeignKey("BuyerId");
		}
	}
}