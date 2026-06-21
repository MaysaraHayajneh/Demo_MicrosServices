using Customer.Application.Contracts.Markers;
using Customer.Application.Contracts.Persistence;
using Customer.Application.Contracts.Services;
using Customer.Application.DTOs.Customers;
using Customer.Domain.Entities;
using Mapster;

namespace Customer.Application.Services
{
	public class CustomerService : ICustomerService, IScope
	{
		private readonly IGenericRepository<CustomerEntity> customerRepos;
		private readonly IUnitOfWork unitOfWork;

		public CustomerService(IGenericRepository<CustomerEntity> productRepos,
			IUnitOfWork unitOfWork)
		{
			this.customerRepos = productRepos;
			this.unitOfWork = unitOfWork;
		}
		public async Task Create(CreateCustomerDTO dto)
		{
			ArgumentNullException.ThrowIfNull(dto);
			var product = dto.Adapt<CustomerEntity>();
			await customerRepos.Create(product);
			await unitOfWork.CommitAsync();
		}
		public async Task Delete(int Id)
		{
			var product = await customerRepos.GetById(Id);
			ArgumentNullException.ThrowIfNull(product);
			customerRepos.Delete(product);
			await unitOfWork.CommitAsync();

		}

		public async Task<IReadOnlyList<GetAllCustomersDTO>> GetAll()
		{
			var products = await customerRepos.GetAll();
			return products.Adapt<IReadOnlyList<GetAllCustomersDTO>>();
		}

		public async Task<GetCustomerDTO> GetById(int id)
		{
			var product = await customerRepos.GetById(id);
			ArgumentNullException.ThrowIfNull(product);
			return product.Adapt<GetCustomerDTO>();
		}

		public async Task Update(UpdateCustomerDTO dto)
		{
			var product = await customerRepos.GetById(dto.Id, false);

			product.Adapt<UpdateCustomerDTO>();

			await unitOfWork.CommitAsync();

		}
	}
}
