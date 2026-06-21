using Order.Application.DTOs.OrderItems;

namespace Order.Application.DTOs.Orders
{ 
	public class CreateOrderDTO
	{
		public int CustomerId { get; set; }
		public List<CreateOrderItemDTO> OrderItems { get; set; } = new List<CreateOrderItemDTO>();
	}
}
