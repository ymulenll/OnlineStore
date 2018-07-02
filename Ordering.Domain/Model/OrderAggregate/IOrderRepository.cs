
using Ordering.Domain.Common;

namespace Ordering.Domain.Model.OrderAggregate
{
	public interface IOrderRepository : IRepository<Order>
	{
		void Add(Order order);

		void Update(Order order);

		Order Get(int orderId);
	}
}