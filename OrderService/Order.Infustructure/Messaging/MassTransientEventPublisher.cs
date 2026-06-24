using MassTransit;
using Order.Application.Contracts.Messaging;
using SharedContracts.Messages;

namespace Order.Infustructure.Messaging
{
    internal class MassTransientEventPublisher(IPublishEndpoint publish) : IEventPublisher
    {
        public async Task PublishOrderCreated(OrderCreatedEvent orderCreatedEvent)
        {
            await publish.Publish(orderCreatedEvent);
        }
    }
}
