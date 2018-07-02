using System.Collections.Generic;
using System.Linq;
using Ordering.Domain.Model.CustomerAggregate;
using Ordering.Domain.Model.ProductAggregate;
using Ordering.Domain.Model.Shared;

namespace Ordering.Domain.Model.ShoppingCartAggregate
{
	public class ShoppingCart
	{
		private ShoppingCart()
		{
			Items = new List<ShoppingCartItem>();
		}

		public static ShoppingCart CreateEmpty(Customer buyer)
		{
			var model = new ShoppingCart { Buyer = buyer };
			return model;
		}

		public ShoppingCart AddItem(int quantity, Product product)
		{
			var existingItem = (from i in Items where i.Product.Id == product.Id select i).SingleOrDefault();
			if (existingItem != null)
			{
				existingItem.Quantity++;
				return this;
			}

			// Create new item
			Items.Add(ShoppingCartItem.Create(quantity, product));
			return this;
		}

		public Money GetTotal()
		{
			var total = (decimal)0;
			foreach (var item in Items)
			{
				total = total + item.Quantity * item.Product.UnitPrice.Value;
			}
			return new Money(Currency.Default, total);
		}

		public Customer Buyer { get; private set; }

		public IList<ShoppingCartItem> Items { get; private set; }
	}
}
