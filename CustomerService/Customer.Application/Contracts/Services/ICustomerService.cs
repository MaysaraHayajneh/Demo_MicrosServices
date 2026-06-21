using Customer.Application.DTOs.Customers;

namespace Customer.Application.Contracts.Services
{
	public interface ICustomerService
	{
		Task Create(CreateCustomerDTO dto);
		Task Delete(int Id);
		Task Update(UpdateCustomerDTO dto);
		Task<IReadOnlyList<GetAllCustomersDTO>> GetAll();
		Task<GetCustomerDTO> GetById(int id); 
	}
}
