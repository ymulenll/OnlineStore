
namespace Ordering.Domain.Model.OrderAggregate
{
	public enum OrderState
	{
		Canceled = 0,
		Pending = 1,
		Shipped = 2,
		Archived = 3
	}
}