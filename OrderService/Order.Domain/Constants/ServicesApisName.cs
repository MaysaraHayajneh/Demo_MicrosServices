namespace Order.Domain.Constants
{
	public static class ServicesApisName
	{
		private static readonly string ClientAddress = "http://localhost:5140/";
		private static readonly string ProductAddress = "https://localhost:7215/";
		public static string GetCustomerEndpoint(int id)
			=> $"{ClientAddress}api/Customer/GetBy/{id}";
		public static string GetProductEndpoint(int id) 
			=> $"{ProductAddress}api/Product/GetBy/{id}";

	}
}
