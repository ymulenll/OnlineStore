using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application;
using Ordering.Application.InputModels;

namespace Web.MVC.Controllers
{
	public class OrderController : Controller
	{
		private readonly IOrdersService _ordersService;

		protected OrderController(IOrdersService ordersService)
		{
			_ordersService = ordersService;
		}

		public IActionResult PlaceTheOrder()
		{
			var cart = RetrieveCurrentShoppingCart();

			var viewModel = _ordersService.PlaceOrder(cart);

			return View("OrderPlaced", viewModel);
		}

		private ShoppingCartInputModel RetrieveCurrentShoppingCart()
		{
			throw new NotImplementedException();
		}
	}
}