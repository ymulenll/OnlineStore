
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Model.CustomerAggregate;
using Ordering.Domain.Model.OrderAggregate;
using Ordering.Infrastructure.Mappings;

namespace Ordering.Infrastructure
{
	public class OrderingContext : DbContext
	{
		public const string DEFAULT_SCHEMA = "ordering";

		public OrderingContext()
		{
		}

		public DbSet<Order> Orders { get; set; }

		public DbSet<OrderItem> OrderItems { get; set; }

		public DbSet<Customer> Customer { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CustomerMap());
			modelBuilder.ApplyConfiguration(new OrderMap());
			modelBuilder.ApplyConfiguration(new OrderItemMap());
		}
	}
}