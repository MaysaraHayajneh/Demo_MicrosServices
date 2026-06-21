namespace Customer.Domain.Entities
{
	public class CustomerEntity : Entity
	{

		public string FirstName { get; set; } 
		public string LastName { get; set; }

		public string Email { get; set; }

		public string PhoneNumber { get; set; }
	}
}
