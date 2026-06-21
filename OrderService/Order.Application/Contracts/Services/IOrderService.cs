using Order.Application.DTOs.Orders;

namespace Order.Application.Contracts.Services
{
	public interface IOrderService 
	{
		Task Create(CreateOrderDTO dto);
		Task Delete(int Id);
		Task Update(UpdateOrderDTO dto);
		Task<IReadOnlyList<GetAllOrderDTO>> GetAll();
		Task<GetOrderDTO> GetById(int id);
	}
}
