using Customer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Customer.Infustructure.Persistence.Configuration
{
	internal class CutomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
	{
		public void Configure(EntityTypeBuilder<CustomerEntity> builder)
		{
			builder.HasKey(x => x.Id);

			builder.ToTable("Customers");

			builder.Property(p => p.FirstName)
				.IsRequired();

			builder.Property(p => p.LastName)
				.IsRequired();

			builder.Property(p => p.Email)
				.IsRequired();

			builder.Property(p => p.PhoneNumber)
				.IsRequired();
		}
	}
}
