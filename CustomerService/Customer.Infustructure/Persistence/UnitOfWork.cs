using Customer.Application.Contracts.Persistence;
using Customer.Infustructure.Persistence.Context;

namespace Customer.Infustructure.Persistence
{
	internal class UnitOfWork(CustomerDbContext context) : IUnitOfWork
	{
		public async Task CommitAsync()
		{
			await context.SaveChangesAsync();
		}
	}
}
