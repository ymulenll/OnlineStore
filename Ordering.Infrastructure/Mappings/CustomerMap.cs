using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Model.CustomerAggregate;

namespace Ordering.Infrastructure.Mappings
{
	public class CustomerMap : IEntityTypeConfiguration<Customer>
	{
		public void Configure(EntityTypeBuilder<Customer> customerConfiguration)
		{
			customerConfiguration.ToTable("customers", OrderingContext.DEFAULT_SCHEMA);

			customerConfiguration.HasKey(customer => customer.CustomerId);

			customerConfiguration.Property(customer => customer.CustomerId)
				.IsRequired();

			customerConfiguration.OwnsOne(customer => customer.Address);
		}
	}
}