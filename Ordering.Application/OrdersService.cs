
using System.Globalization;
using Ordering.Application.ExternalServices;
using Ordering.Application.InputModels;
using Ordering.Application.ViewModel;
using Ordering.Domain.Model.OrderAggregate;

namespace Ordering.Application
{
	public class OrdersService : IOrdersService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IShippingService _shippingService;

		public OrdersService(IOrderRepository orderRepository, IShippingService shippingService)
		{
			_orderRepository = orderRepository;
			_shippingService = shippingService;
		}

		public OrderPlacedViewModel PlaceOrder(ShoppingCartInputModel cart)
		{
			// 1. Create order in memory.
			var order = new Order(cart.ShoppingCart.Buyer);

			foreach (var item in cart.ShoppingCart.Items)
			{
				order.AddOrderItem(item.Quantity, item.Product);
			}

			// 2 Store order
			_orderRepository.Add(order);

			// 3. Ship
			var shipmentDetails = _shippingService.SendRequestForDelivery(order);

			// 4. Prepare view model
			var viewModel = new OrderPlacedViewModel
			{
				OrderId = order.Id.ToString(CultureInfo.InvariantCulture),
				ShippingDetails = shipmentDetails
			};

			return viewModel;
		}
	}
}