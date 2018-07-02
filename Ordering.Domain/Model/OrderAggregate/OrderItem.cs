using Ordering.Domain.Common;
using Ordering.Domain.Exceptions;
using Ordering.Domain.Model.ProductAggregate;

namespace Ordering.Domain.Model.OrderAggregate
{
	public class OrderItem : Entity
	{
		public Product Product { get; private set; }

		public Order Order { get; private set; }

		protected OrderItem(){}

		public OrderItem(Order order, int quantity, Product product)
		{
			if (quantity <= 0)
			{
				throw new OrderingDomainException("Invalid quantity of units");
			}

			Order = order;
			Quantity = quantity;
			Product = product;
		}

		public int Quantity { get; private set; }

		public void AddUnits(int units)
		{
			if (units < 0)
			{
				throw new OrderingDomainException("Invalid units");
			}

			Quantity++;
		}
	}
}