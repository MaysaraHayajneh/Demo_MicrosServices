using Customer.Domain.Entities;

namespace Customer.Application.Contracts.Persistence
{
	public interface IGenericRepository<T> where T : Entity
	{
		Task Create(T entity);
		void Delete(T entity);
		void Update(T entity);
		Task<IReadOnlyList<T>> GetAll();
		Task<T?> GetById(int id, bool disableTracking = true);
	}
}
