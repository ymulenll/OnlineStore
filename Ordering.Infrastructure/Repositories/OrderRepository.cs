using System;
using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Common;
using Ordering.Domain.Model.OrderAggregate;

namespace Ordering.Infrastructure.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private readonly OrderingContext _context;
		
		public OrderRepository(OrderingContext context)
		{
			_context = context
				?? throw new ArgumentNullException(nameof(context));
		}

		public void Add(Order order)
		{
			_context.Orders.Add(order);
			_context.SaveChanges();
		}

		public Order Get(int orderId)
		{
			var order = _context.Orders.Find(orderId);
			if (order != null)
			{
				_context.Entry(order)
					.Collection(o => o.OrderItems).Load();
			}

			return order;
		}

		public void Update(Order order)
		{
			_context.Entry(order).State = EntityState.Modified;
			_context.SaveChanges();
		}
	}
}