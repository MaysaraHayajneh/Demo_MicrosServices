using Mapster;
using Order.Application.DTOs.Orders;
using Order.Domain.Entities;

namespace Order.Application.Mapping.Orders
{
	internal sealed class OrderMappingConfig : IRegister 
	{
		public void Register(TypeAdapterConfig config)
		{
			AddOrderConfig(config);
		} 

		#region AddProductMapperConfig
		private static void AddOrderConfig(TypeAdapterConfig config)
		{
			config.NewConfig<CreateOrderDTO, OrderEntity>()
				.Map(dest => dest.CustomerId, src => src.CustomerId)
				.Map(dest => dest.OrderItems, src => src.OrderItems);
		}

		#endregion



	}


}
