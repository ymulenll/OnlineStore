
using Ordering.Domain.Model.OrderAggregate;

namespace Ordering.Application.ExternalServices
{
	public interface IShippingService
	{
		OrderShippingConfirmation SendRequestForDelivery(Order order);
	}
}