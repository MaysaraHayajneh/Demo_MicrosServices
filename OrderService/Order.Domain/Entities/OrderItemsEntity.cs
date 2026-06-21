namespace Order.Domain.Entities
{
	public class OrderItemsEntity : Entity
	{
		private OrderItemsEntity()
		{

		}

		public OrderItemsEntity(int productId, string productName, int quantity, decimal unitPrice)
		{
			ProductId = productId;
			ProductName = productName;
			Quantity = quantity;
			UnitPrice = unitPrice;
		}
		public int OrderId { get; set; }
		public OrderEntity Order { get; set; }
		public int ProductId { get; set; }
		public string ProductName { get; set; }
		public int Quantity { get; set; }
		public decimal UnitPrice { get; set; }
		public decimal TotalPrice => Quantity * UnitPrice;

	}
}
