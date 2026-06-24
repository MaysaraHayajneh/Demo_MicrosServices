namespace SharedContracts.Messages
{
    public record OrderCreatedEvent(List<ProductDetails> Products);

    public class ProductDetails
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}