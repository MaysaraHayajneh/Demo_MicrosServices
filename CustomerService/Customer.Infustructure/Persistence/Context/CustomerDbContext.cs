using Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Customer.Infustructure.Persistence.Context
{
	public class CustomerDbContext : DbContext
	{
		public DbSet<CustomerEntity> Customers { get; set; }
		public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDbContext).Assembly);
		}
	}
}
