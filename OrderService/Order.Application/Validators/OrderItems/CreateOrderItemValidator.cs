using FluentValidation;
using Order.Application.DTOs.OrderItems;

namespace Order.Application.Validators.OrderItems
{
	internal class CreateOrderItemValidator : AbstractValidator<CreateOrderItemDTO>
	{
		public CreateOrderItemValidator()
		{
			RuleFor(oi => oi.Quantity)
				.GreaterThan(0)
				.WithMessage("graeter than 0");

			RuleFor(oi => oi.ProductId)
				.GreaterThan(0)
				.WithMessage("required");

	

		}
	}
}
