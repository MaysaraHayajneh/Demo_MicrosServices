using Order.Application.DTOs.Customers;

namespace Order.Application.Contracts.Clients
{
	public interface ICustomerServiceClient
	{
		Task<GetCustomerDto?> GetCustomerAsync(int customerId);
	}
}
