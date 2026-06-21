using Customer.Application.DTOs.Customers;
using Customer.Domain.Entities;
using Mapster;

namespace Customer.Application.Mapping.Customers;

internal sealed class CustomerMappingConfig : IRegister
{
	public void Register(TypeAdapterConfig config)
	{ 
		AddProductConfig(config);
	}

	#region AddProductMapperConfig
	private static void AddProductConfig(TypeAdapterConfig config)
	{
		config.NewConfig<CreateCustomerDTO, CustomerEntity>()
			.Map(dest => dest.Email, src => src.Email)
			.Map(dest => dest.FirstName, src => src.FirstName)
			.Map(dest => dest.LastName, src => src.LastName)
			.Map(dest => dest.PhoneNumber, src => src.PhoneNumber);
	}
	#endregion



}
