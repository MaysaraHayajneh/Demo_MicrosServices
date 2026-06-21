using Order.Application.DTOs.Products;

namespace Order.Application.Contracts.Services
{
	public interface IProductService
	{
		Task Create(CreateProductDTO dto);
		Task Delete(int Id);
		Task Update(UpdateProductDTO dto);
		Task<IReadOnlyList<GetAllProductDTO>> GetAll();
		Task<GetProductDTO> GetById(int id);
	}
}
