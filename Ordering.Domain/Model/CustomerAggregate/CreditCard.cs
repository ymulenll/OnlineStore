
using System;
using Ordering.Domain.Common;
using Ordering.Domain.Exceptions;

namespace Ordering.Domain.Model.CustomerAggregate
{
	public class CreditCard : ValueObject<CreditCard>
	{
		public CreditCardType Type { get; private set; }

		public DateTime ExpirationDate { get; private set; }

		public string OwnerName { get; private set; }

		public string CardNumber { get; private set; }

		public string SecurityNumber { get; private set; }

		public static CreditCard NullCreditCard = new CreditCard();

		public CreditCard(CreditCardType cardType, string cardNumber, string securityNumber, string ownerName, DateTime expiration)
		{
			CardNumber = !string.IsNullOrWhiteSpace(cardNumber) ? cardNumber : throw new OrderingDomainException(nameof(cardNumber));
			SecurityNumber = !string.IsNullOrWhiteSpace(securityNumber) ? securityNumber : throw new OrderingDomainException(nameof(securityNumber));
			OwnerName = !string.IsNullOrWhiteSpace(ownerName) ? ownerName : throw new OrderingDomainException(nameof(ownerName));

			if (expiration < DateTime.UtcNow)
			{
				throw new OrderingDomainException(nameof(expiration));
			}

			ExpirationDate = expiration;
			Type = cardType;
		}

		protected CreditCard()
		{
			Type = CreditCardType.Unknown;
			ExpirationDate = DateTime.UtcNow;
			CardNumber = string.Empty;
			OwnerName = string.Empty;
			SecurityNumber = string.Empty;
		}
	}
}