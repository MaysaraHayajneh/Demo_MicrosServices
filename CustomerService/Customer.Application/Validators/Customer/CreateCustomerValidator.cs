using Customer.Application.DTOs.Customers;
using Domain.Enums.SystemMessages;
using FluentValidation;

namespace Customer.Application.Validators.Customer
{
	internal sealed class CreateCustomerValidator : AbstractValidator<CreateCustomerDTO>
	{
		public CreateCustomerValidator()
		{
			RuleFor(x => x.FirstName)
				.NotEmpty()
				.WithMessage(ValidationMessageEnum.NameRequired.ToString())
				.Must(IsValidName)
				.WithMessage(ValidationMessageEnum.NameMustBeLetters.ToString());

			RuleFor(x => x.LastName)
			    .NotEmpty()
				.WithMessage(ValidationMessageEnum.PriceLimit.ToString());

			RuleFor(x => x.PhoneNumber)
				.NotEmpty()
				.WithMessage(ValidationMessageEnum.QuantityLimit.ToString());
		}

		private static bool IsValidName(string? name)
		{
			return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
		}
	}
}
