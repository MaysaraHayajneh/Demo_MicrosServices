namespace Domain.Entities
{
	public class ProductEntity : Entity
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int Quantity { get; set; }
	}
}
