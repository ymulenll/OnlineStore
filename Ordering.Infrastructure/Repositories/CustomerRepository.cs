
using Ordering.Domain.Common;
using Ordering.Domain.Model.CustomerAggregate;

namespace Ordering.Infrastructure.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
#pragma warning disable 169
		private readonly OrderingContext _context;
#pragma warning restore 169
		
		public Customer Add(Customer customer)
		{
			throw new System.NotImplementedException();
		}

		public Customer Update(Customer customer)
		{
			throw new System.NotImplementedException();
		}

		public Customer Find(string customerIdentity)
		{
			throw new System.NotImplementedException();
		}

		public Customer FindById(string id)
		{
			throw new System.NotImplementedException();
		}
	}
}