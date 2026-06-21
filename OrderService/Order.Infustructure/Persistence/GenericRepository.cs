using Microsoft.EntityFrameworkCore;
using Order.Application.Contracts.Persistence;
using Order.Domain.Entities;
using Order.Infustructure.Persistence.Context;

namespace Order.Infustructure.Persistence
{
	internal class GenericRepository<T> : IGenericRepository<T> where T : Entity
	{
		private readonly DbSet<T> _dbSet;

		public GenericRepository(OrderDbContext productDbContext)
		{
			_dbSet = productDbContext.Set<T>();
		}
		public async Task Create(T entity)
		{
			await _dbSet.AddAsync(entity);
		}

		public void Delete(T entity)
		{
			_dbSet.Remove(entity);
		}

		public async Task<IReadOnlyList<T>> GetAll()
		{
			return (await _dbSet.AsNoTracking().ToListAsync())
				.AsReadOnly();
		}

		public async Task<T?> GetById(int id, bool disableTracking = true)
		{
			IQueryable<T>  qurable = _dbSet;
			if (disableTracking) _dbSet.AsNoTracking();
			return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
		}

		public void Update(T entity)
		{
			_dbSet.Update(entity);
		}
	}
}
