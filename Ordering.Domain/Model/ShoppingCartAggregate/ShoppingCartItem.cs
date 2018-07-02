using Ordering.Domain.Model.ProductAggregate;

namespace Ordering.Domain.Model.ShoppingCartAggregate
{
	public class ShoppingCartItem
	{
		public static ShoppingCartItem Create(int quantity, Product product)
		{
			var item = new ShoppingCartItem { Quantity = quantity, Product = product };
			return item;
		}

		private ShoppingCartItem()
		{
			Quantity = 0;
			Product = Product.NullProduct;
		}

		public int Quantity { get; set; }
		public Product Product { get; set; }
	}
}