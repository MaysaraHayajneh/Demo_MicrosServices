using Order.Application.DTOs.OrderItems;

namespace Order.Application.DTOs.Orders
{
	public class GetAllOrderDTO
	{
		public int Id { get; set; }
		public int CustomerId { get; set; } 
		public decimal TotalPrice { get; set; }
		public List<GetOrderItemDTO> OrderItems { get; set; } = new List<GetOrderItemDTO>();
	}
}
