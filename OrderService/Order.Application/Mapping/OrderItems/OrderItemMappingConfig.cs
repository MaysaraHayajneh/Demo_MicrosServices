using Mapster;
using Order.Application.DTOs.OrderItems;
using Order.Application.DTOs.Orders;
using Order.Domain.Entities;

namespace Order.Application.Mapping.OrderItems
{
	internal class OrderItemMappingConfig : IRegister
	{
		public void Register(TypeAdapterConfig config)
		{
			AddOrderItemConfig(config);
		}

		#region AddOrdrtItemMapperConfig
		private static void AddOrderItemConfig(TypeAdapterConfig config)
		{
			config.NewConfig<CreateOrderItemDTO, OrderItemsEntity>()
				.Map(dest => dest.ProductId, src => src.ProductId)
				.Map(dest => dest.Quantity, src => src.Quantity);
		}

		#endregion
	}
}
