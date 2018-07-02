
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Ordering.Domain.Model.ProductAggregate;
using Ordering.Domain.Model.ShoppingCartAggregate;

namespace Ordering.Application.InputModels
{
	public class ShoppingCartInputModel
	{
		private ShoppingCartInputModel()
		{
			EnableEditOnShoppingCart = true;
		}
		
		public ShoppingCart ShoppingCart { get; private set; }

		public bool EnableEditOnShoppingCart { get; set; }
	}
}