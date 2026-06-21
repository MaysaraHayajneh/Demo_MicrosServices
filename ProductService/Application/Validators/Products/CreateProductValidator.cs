using Order.Application.DTOs.Products;
using Domain.Enums.SystemMessages;
using FluentValidation;
using FluentValidation.Results;

namespace Order.Application.Validators.Products
{
	internal sealed class CreateProductValidator : AbstractValidator<CreateProductDTO>
	{
		public CreateProductValidator()
		{
			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage(ValidationMessageEnum.NameRequired.ToString())
				.Must(IsValidName)
				.WithMessage(ValidationMessageEnum.NameMustBeLetters.ToString());

			RuleFor(x => x.Price)
				.GreaterThan(0)
				.WithMessage(ValidationMessageEnum.PriceLimit.ToString());

			RuleFor(x => x.Quantity)
				.GreaterThan(0)
				.WithMessage(ValidationMessageEnum.QuantityLimit.ToString());
		}

		private static bool IsValidName(string? name)
		{
			return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
		}
	}
}
