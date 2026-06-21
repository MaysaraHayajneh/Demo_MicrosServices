using Order.Application.Contracts.Clients;
using Order.Application.DTOs.Customers;
using Order.Domain.Constants;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;

namespace Order.Infustructure.Clients
{
	public class CustomerServiceClient : ICustomerServiceClient
	{
		private readonly HttpClient httpClient;

		public CustomerServiceClient(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		public async Task<GetCustomerDto?> GetCustomerAsync(int customerId)
		{
			Uri uri = new Uri(ServicesApisName.GetCustomerEndpoint(customerId));
			return await httpClient.GetFromJsonAsync<GetCustomerDto>(uri);
		}
	}
}
