using Infustructure.Persistence.Context;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using SharedContracts.Messages;

namespace Infustructure.Consumers
{
    internal class OrderCraetedConsumer : IConsumer<OrderCreatedEvent>
    {
        private readonly ProductDbContext _productDbContext;

        public OrderCraetedConsumer(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }
        public async Task Consume(ConsumeContext<OrderCreatedEvent> context)
        {
            var productsQuantityMap = context.Message.Products.ToDictionary(p => p.ProductId, p => p.Quantity);

            var products = await _productDbContext.Products.Where(p => productsQuantityMap.Keys.Contains(p.Id)).ToListAsync();

            if (products.Count == 0) return;

            foreach (var product in products)
            {
                product.UpdateStock(productsQuantityMap[product.Id]);
            }

            await _productDbContext.SaveChangesAsync();
        }
    }
}
