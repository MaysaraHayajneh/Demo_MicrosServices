using Order.Application.Contracts.Persistence;
using Domain.Entities;
using Infustructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Infustructure.Persistence
{
	internal class GenericRepository<T> : IGenericRepository<T> where T : Entity
	{
		private readonly DbSet<T> _dbSet;

		public GenericRepository(ProductDbContext productDbContext)
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
