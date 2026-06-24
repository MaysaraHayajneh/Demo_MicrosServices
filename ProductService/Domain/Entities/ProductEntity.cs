namespace Domain.Entities
{
    public class ProductEntity : Entity
    {
        public ProductEntity(string name, decimal price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }


        public void UpdateStock(int quantity)
        {
            if (quantity < 0)
                throw new InvalidOperationException("Quantity cannot be negative.");
            Quantity -= quantity;
        }
    }
}
