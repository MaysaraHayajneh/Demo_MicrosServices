using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infustructure.Persistence.Context
{
	public class ProductDbContext : DbContext
	{
		public DbSet<ProductEntity> Products { get; set; }
		public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductDbContext).Assembly);
		}
	}
}
