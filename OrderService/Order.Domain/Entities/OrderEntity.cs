using Order.Domain.Enums.Business;

namespace Order.Domain.Entities
{
	public class OrderEntity : Entity
	{
		private OrderEntity()
		{

		}
		public OrderEntity(int customerId)
		{
			CustomerId = customerId;
			OrderStatus = OrderStatus.Pending;
		}
		public int CustomerId { get; private set; }
		public OrderStatus OrderStatus { get; private set; }
		public DateTime CreatedAt { get; private set; }

		public decimal TotalPrice { get; private set; }
		public ICollection<OrderItemsEntity> OrderItems { get; private set; } = new List<OrderItemsEntity>();

		public void AddItem(int productId, string productName, decimal price, int quantity)
		{
			if (quantity <= 0) throw new Exception("Quantity must be greater than 0"); 

			OrderItems.Add(new OrderItemsEntity(productId, productName, quantity, price));

			CalculateTotalPrice();
		}

		private void CalculateTotalPrice()
		{
			TotalPrice = OrderItems.Sum(oi => oi.Quantity * oi.UnitPrice);
		}


	}
}
