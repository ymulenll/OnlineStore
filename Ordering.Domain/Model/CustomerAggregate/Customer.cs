using System;
using Ordering.Domain.Common;

namespace Ordering.Domain.Model.CustomerAggregate
{
	public class Customer : Entity, IAggregateRoot
	{
		public Customer(string userName)
		{
			CustomerId = !string.IsNullOrWhiteSpace(userName) ? userName : throw new ArgumentNullException(nameof(userName));
			Address = Address.Create();
			CreditCard = CreditCard.NullCreditCard;
		}

		public string CustomerId { get; private set; }

		public Address Address { get; private set; }

		public CreditCard CreditCard { get; private set; }

		protected Customer()
		{
		}

		public void SetAddress(Address address)
		{
			if (address != null)
				Address = address;
		}

		public Customer SetPaymentDetails(CreditCard card)
		{
			if (card != null)
				CreditCard = card;

			return this;
		}
	}
}