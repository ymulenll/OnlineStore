using Ordering.Application.ExternalServices;

namespace Ordering.Application.ViewModel
{
	public class OrderPlacedViewModel
	{
		public OrderPlacedViewModel()
		{
			OrderId = "---";
			ShippingDetails = new OrderShippingConfirmation();
		}

		public string OrderId { get; set; }

		public OrderShippingConfirmation ShippingDetails { get; set; }
	}
}