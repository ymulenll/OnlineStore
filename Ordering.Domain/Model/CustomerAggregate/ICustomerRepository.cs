
using Ordering.Domain.Common;

namespace Ordering.Domain.Model.CustomerAggregate
{
	public interface ICustomerRepository : IRepository<Customer>
	{
		Customer Add(Customer customer);

		Customer Update(Customer customer);

		Customer Find(string customerIdentity);

		Customer FindById(string id);
	}
}