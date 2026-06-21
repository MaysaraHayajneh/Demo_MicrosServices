namespace Customer.Application.Contracts.Persistence
{
	public interface IUnitOfWork
	{
		public Task CommitAsync();
	}
}
