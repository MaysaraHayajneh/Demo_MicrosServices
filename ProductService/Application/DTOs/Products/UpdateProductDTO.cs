namespace Order.Application.DTOs.Products
{
	public class UpdateProductDTO
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}
