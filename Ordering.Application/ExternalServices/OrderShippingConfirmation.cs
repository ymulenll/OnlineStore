using System;

namespace Ordering.Application.ExternalServices
{
	public class OrderShippingConfirmation
	{
		public OrderShippingConfirmation()
		{
			TrackingId = string.Empty;
			ExpectedShipDate = DateTime.MaxValue;
		}

		public string TrackingId { get; set; }

		public DateTime ExpectedShipDate { get; set; }
	}
}