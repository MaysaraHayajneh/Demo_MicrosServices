using SharedContracts.Messages;

namespace Order.Application.Contracts.Messaging
{
    public interface IEventPublisher
    {
        Task PublishOrderCreated(OrderCreatedEvent orderCreatedEvent);
    }
}
