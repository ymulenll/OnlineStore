
using Ordering.Domain.Common;
using Ordering.Domain.Model.Shared;

namespace Ordering.Domain.Model.ProductAggregate
{
	public class Product : Entity, IAggregateRoot
	{
		public static Product NullProduct = new Product{Description = string.Empty, UnitPrice = Money.Zero, StockLevel = 0};

		protected Product()
		{
		}
		
		public string Description { get; private set; }

		public Money UnitPrice { get; private set; }

		public int StockLevel { get; private set; }

		public bool Featured { get; private set; }

		public int GetStockForDisplay()
		{
			return StockLevel / 2;
		}
	}
}