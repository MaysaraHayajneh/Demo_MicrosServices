using Order.Application.Contracts.Markers;
using Order.Application.Contracts.Persistence;
using Order.Application.Contracts.Services;
using Order.Application.DTOs.Products;
using Domain.Entities;
using Mapster;
using MapsterMapper;

namespace Order.Application.Services
{
	public class ProductService : IProductService, IScope
	{
		private readonly IGenericRepository<ProductEntity> productRepos;
		private readonly IUnitOfWork unitOfWork;

		public ProductService(IGenericRepository<ProductEntity> productRepos,
			IUnitOfWork unitOfWork)
		{
			this.productRepos = productRepos;
			this.unitOfWork = unitOfWork;
		}
		public async Task Create(CreateProductDTO dto)
		{
			ArgumentNullException.ThrowIfNull(dto);
			var product = dto.Adapt<ProductEntity>();
			await productRepos.Create(product);
			await unitOfWork.CommitAsync();
		}
		public async Task Delete(int Id)
		{
			var product = await productRepos.GetById(Id);
			ArgumentNullException.ThrowIfNull(product);
			productRepos.Delete(product);
			await unitOfWork.CommitAsync();

		}

		public async Task<IReadOnlyList<GetAllProductDTO>> GetAll()
		{
			var products = await productRepos.GetAll();
			return products.Adapt<IReadOnlyList<GetAllProductDTO>>();
		}

		public async Task<GetProductDTO> GetById(int id)
		{
			var product = await productRepos.GetById(id);
			ArgumentNullException.ThrowIfNull(product);
			return product.Adapt<GetProductDTO>();
		}

		public async Task Update(UpdateProductDTO dto)
		{
			var product = await productRepos.GetById(dto.Id, false);

			product.Adapt<UpdateProductDTO>();

			await unitOfWork.CommitAsync();

		}
	}
}
