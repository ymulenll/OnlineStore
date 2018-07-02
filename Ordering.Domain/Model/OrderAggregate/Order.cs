
using System;
using System.Collections.Generic;
using System.Linq;
using Ordering.Domain.Common;
using Ordering.Domain.Model.CustomerAggregate;
using Ordering.Domain.Model.ProductAggregate;
using Ordering.Domain.Model.Shared;

namespace Ordering.Domain.Model.OrderAggregate
{
	public class Order: Entity, IAggregateRoot
	{
		public Order(Customer buyer)
		{
			Buyer = buyer;
			Date = DateTime.UtcNow;
			State = OrderState.Pending;
		}

		protected Order()
		{
			Date = DateTime.UtcNow;
			State = State = OrderState.Pending;
		}
		
		public OrderState State { get; private set; }

		public DateTime Date { get; private set; }

		public Customer Buyer { get; private set; }

		private readonly List<OrderItem> _orderItems = new List<OrderItem>();
		public IEnumerable<OrderItem> OrderItems => _orderItems.AsReadOnly();

		public void AddOrderItem(int quantity, Product product)
		{
			var existingItemForProduct =
				_orderItems.SingleOrDefault(item => item.Product.Id == product.Id);

			if (existingItemForProduct != null)
			{
				existingItemForProduct.AddUnits(quantity);
			}
			else
			{
				// Create new item
				var orderItem = new OrderItem(this, quantity, product);
				_orderItems.Add(orderItem);
			}
		}

		public Money GetTotal()
		{
			var total = (decimal)0;
			foreach (var item in _orderItems)
			{
				total = total + item.Quantity * item.Product.UnitPrice.Value;
			}
			return new Money(Currency.Default, total);
		}

		public Order Cancel()
		{
			if (State != OrderState.Pending)
				throw new InvalidOperationException("Can't cancel an order that is not pending.");

			State = OrderState.Canceled;
			return this;
		}

		public Order Archive()
		{
			if (State != OrderState.Shipped)
				throw new InvalidOperationException("Can't archive an order that has not shipped yet.");

			State = OrderState.Canceled;
			return this;
		}

		public Order MarkAsShipped()
		{
			if (State != OrderState.Pending)
				throw new InvalidOperationException(
				        "Can't mark as shipped an order that is not pending.");

			State = OrderState.Shipped;
			return this;
		}



		//public ICollection<OrderItem> Items { get; private set; }

		//public static Order CreateFromShoppingCart(ShoppingCart cart)
		//{
		//	var order = new Order
		//	{
		//		Total = cart.GetTotal(),
		//		State = OrderState.Pending,
		//		Date = DateTime.UtcNow,
		//		Buyer = cart.Buyer
		//	};

		//	foreach (var cartItem in cart.Items)
		//	{
		//		var orderItem = new OrderItem(order, cartItem.Quantity, cartItem.Product);
		//		order.Items.Add(orderItem);
		//	}

		//	return order;
		//}
	}
}