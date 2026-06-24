namespace Application.Contracts.Consumers
{
    public interface IMessageConsumer<T> where T : class
    {
        Task Consume(T message);
    }
}
