using Order.Application.DTOs.Products;
using Domain.Entities;
using Mapster;

namespace Order.Application.Mapping.Products
{
	internal sealed class ProductMappingConfig : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			AddProductConfig(config);
		}

		#region AddProductMapperConfig
		private static void AddProductConfig(TypeAdapterConfig config)
		{
			config.NewConfig<CreateProductDTO, ProductEntity>()
				.Map(dest => dest.Quantity, src => src.Quantity)
				.Map(dest => dest.Name, src => src.Name)
				.Map(dest => dest.Price, src => src.Price);
		}
		#endregion



	}


}
