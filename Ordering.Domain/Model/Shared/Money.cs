
using System;
using Ordering.Domain.Common;

namespace Ordering.Domain.Model.Shared
{
	public class Money : ValueObject<Money>
	{
		public static Money Zero = new Money(Currency.Default, 0);

		public Money(Currency currency, decimal amount)
		{
			Currency = currency;
			Value = amount;
		}

		public Currency Currency { get; private set; }

		public decimal Value { get; private set; }

		#region Operators
		public static Money operator +(Money c1, Money c2)
		{
			if (c1.Currency != c2.Currency)
				throw new ArgumentException("+ operator, c1, c2");
			return new Money(c1.Currency, c1.Value + c2.Value);
		}
		public static Money operator -(Money c1, Money c2)
		{
			if (c1.Currency != c2.Currency)
				throw new ArgumentException("- operator, c1, c2");
			return new Money(c1.Currency, c1.Value - c2.Value);
		}
		public static Money operator +(Money c1, decimal d)
		{
			return new Money(c1.Currency, c1.Value + d);
		}

		public static Money operator *(Money c1, int n)
		{
			return new Money(c1.Currency, c1.Value * n);
		}

		// Operators are NOT commutative by default
		public static Money operator *(int n, Money c1)
		{
			return new Money(c1.Currency, c1.Value * n);
		}
		#endregion
	}
}