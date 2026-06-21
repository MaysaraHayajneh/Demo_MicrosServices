using Order.Application.DTOs.Product;

namespace Order.Application.Contracts.Clients
{
	public interface IProductServiceClient
	{
		public Task<GetProductDTO?> GetProduct(int Id);
	}
}
