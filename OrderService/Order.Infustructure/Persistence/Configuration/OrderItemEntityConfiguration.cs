using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities;

namespace Order.Infustructure.Persistence.Configuration
{
	internal class OrderItemEntityConfiguration : IEntityTypeConfiguration<OrderItemsEntity>
	{
		public void Configure(EntityTypeBuilder<OrderItemsEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(o => o.OrderId)
				.IsRequired();

			builder.Property(o => o.Quantity)
				.IsRequired();

			builder.Property(o => o.TotalPrice)
				.IsRequired();

			builder.Property(o => o.ProductId)
					.IsRequired();

			builder.Property(o => o.ProductName)
				.IsRequired();

			builder.Ignore(o => o.TotalPrice);
		}
	}
}
