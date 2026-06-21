using Order.Application.Contracts.Persistence;
using Order.Infustructure.Persistence.Context;
 
namespace Order.Infustructure.Persistence
{
	internal class UnitOfWork(OrderDbContext context) : IUnitOfWork
	{
		public async Task CommitAsync()
		{
			await context.SaveChangesAsync();
		}
	}
}
