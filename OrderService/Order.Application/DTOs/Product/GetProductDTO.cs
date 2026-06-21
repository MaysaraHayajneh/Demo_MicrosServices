namespace Order.Application.DTOs.Product
{
	public class GetProductDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}
