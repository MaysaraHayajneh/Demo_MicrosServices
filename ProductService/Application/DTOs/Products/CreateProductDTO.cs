namespace Order.Application.DTOs.Products
{
	public class CreateProductDTO
	{
		public string Name { get; set; }
		public int Quantity { get; set; }
		public decimal Price { get; set; }
	}
}
