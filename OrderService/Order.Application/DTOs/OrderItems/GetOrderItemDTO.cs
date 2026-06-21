namespace Order.Application.DTOs.OrderItems
{
	public class GetOrderItemDTO
	{
		public string ProductName { get; set; }
		public int Qunatity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice => UnitPrice * Qunatity;
	}
}
