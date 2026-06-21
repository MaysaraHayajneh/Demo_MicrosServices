namespace Order.Application.DTOs.Orders
{
	public class UpdateOrderDTO 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}
