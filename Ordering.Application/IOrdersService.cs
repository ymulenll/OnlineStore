using Ordering.Application.InputModels;
using Ordering.Application.ViewModel;

namespace Ordering.Application
{
	public interface IOrdersService
	{
	    OrderPlacedViewModel PlaceOrder(ShoppingCartInputModel shoppingCartInputModel);
	}
}