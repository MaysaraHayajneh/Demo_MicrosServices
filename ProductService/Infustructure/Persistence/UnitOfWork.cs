using Order.Application.Contracts.Persistence;
using Infustructure.Persistence.Context;

namespace Infustructure.Persistence
{
	internal class UnitOfWork(ProductDbContext context) : IUnitOfWork
	{
		public async Task CommitAsync()
		{
			await context.SaveChangesAsync();
		}
	}
}
