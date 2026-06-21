using FluentValidation;
using Order.Application.DTOs.Orders;
using Order.Application.Validators.OrderItems;
using Order.Domain.Enums.SystemMessages;

namespace Order.Application.Validators.Orders
{
	internal sealed class CreateOrderValidator : AbstractValidator<CreateOrderDTO>
	{
		public CreateOrderValidator()
		{
			RuleFor(x => x.CustomerId)
				.NotEmpty()
				.WithMessage(ValidationMessageEnum.NameRequired.ToString())
				.WithMessage(ValidationMessageEnum.NameMustBeLetters.ToString());

			RuleFor(x => x.OrderItems)
				.NotEmpty();

			RuleForEach(x => x.OrderItems)
				.SetValidator(new CreateOrderItemValidator());
		}


	}
}
