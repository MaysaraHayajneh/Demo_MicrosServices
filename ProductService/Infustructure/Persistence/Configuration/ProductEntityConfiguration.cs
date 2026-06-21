using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infustructure.Persistence.Configuration
{
	internal class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
	{
		public void Configure(EntityTypeBuilder<ProductEntity> builder)
		{
			builder.HasKey(x => x.Id);


			builder.Property(p => p.Name)
				.IsRequired();

			builder.Property(p => p.Price)
				.IsRequired();

			builder.Property(p => p.Quantity)
				.IsRequired();
		}
	}
}
