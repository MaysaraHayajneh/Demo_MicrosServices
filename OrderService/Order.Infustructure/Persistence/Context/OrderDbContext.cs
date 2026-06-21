using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;

namespace Order.Infustructure.Persistence.Context
{
	public class OrderDbContext : DbContext
	{
		public DbSet<OrderEntity> Orders { get; set; }
		public DbSet<OrderItemsEntity> OrderItems { get; set; }
		public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
		{

		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(OrderDbContext).Assembly);
		}
	}
}
