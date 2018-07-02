using Ordering.Domain.Common;

namespace Ordering.Domain.Model.CustomerAggregate
{
	public class Address : ValueObject<Address>
	{
		public static Address Create(
			string street = "", string number = "", string city = "", string zip = "", string country = "")
		{
			var address = new Address
			{
				Street = street,
				Number = number,
				City = city,
				Zip = zip,
				Country = country
			};

			return address;
		}

		public string Street { get; private set; }

		public string Number { get; private set; }

		public string City { get; private set; }

		public string Zip { get; private set; }

		public string Country { get; private set; }
	}
}