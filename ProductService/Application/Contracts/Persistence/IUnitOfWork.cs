namespace Order.Application.Contracts.Persistence
{
	public interface IUnitOfWork
	{
		public Task CommitAsync();
	}
}
