using Order.Application.Contracts.Clients;
using Order.Application.DTOs.Product;
using Order.Domain.Constants;
using System.Net.Http.Json;

namespace Order.Infustructure.Clients
{
	public class ProductServcieClient : IProductServiceClient
	{
		private readonly HttpClient httpClient;

		public ProductServcieClient(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}
		public async Task<GetProductDTO?> GetProduct(int id)
		{
			Uri uri = new Uri(ServicesApisName.GetProductEndpoint(id));
			return await httpClient.GetFromJsonAsync<GetProductDTO>(uri);
		}
	}
}
