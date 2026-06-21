using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Order.Domain.Entities;

namespace Order.Infustructure.Persistence.Configuration
{
	internal class OrtderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
	{
		public void Configure(EntityTypeBuilder<OrderEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(o => o.CustomerId)
				.IsRequired();

			builder.Property(o => o.OrderStatus)
				.HasConversion<string>()
				.IsRequired();

			builder.Property(o => o.TotalPrice)
				.IsRequired();

			builder.Property(o => o.CreatedAt)
				.HasDefaultValueSql("GETUTCDATE()");

			builder.HasMany(o => o.OrderItems)
				.WithOne(oi => oi.Order)
				.HasForeignKey(oi => oi.OrderId);

		}
	}
}
