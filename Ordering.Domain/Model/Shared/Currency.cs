using System;
using System.Collections.Generic;
using System.Text;
using Ordering.Domain.Common;

namespace Ordering.Domain.Model.Shared
{
	public class Currency : ValueObject<Currency>
	{
		public static Currency Default = new UsdCurrency();

		protected Currency(string symbol, string name)
		{
			Symbol = symbol;
			Name = name;
		}

		public string Symbol { get; private set; }

		public string Name { get; private set; }
	}

	public class UsdCurrency : Currency
	{
		public static UsdCurrency Instance = new UsdCurrency();

		public UsdCurrency()
			: base("$", "USD")
		{
		}
	}

	public class EurCurrency : Currency
	{
		public static EurCurrency Instance = new EurCurrency();

		public EurCurrency()
			: base("€", "EUR")
		{
		}
	}

	public class GbpCurrency : Currency
	{
		public static GbpCurrency Instance = new GbpCurrency();

		public GbpCurrency()
			: base("£", "GBP")
		{
		}
	}
}