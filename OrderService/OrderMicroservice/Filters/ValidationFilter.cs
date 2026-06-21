using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using HttpMethod = System.Net.Http.HttpMethod;

namespace OrderMicroservice.Filters;

public class ValidationFilter : IAsyncActionFilter
{
	public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
	{
		var method = context.HttpContext.Request.Method;

		if (method.Equals(HttpMethod.Delete)) { await next(); return; }

		IServiceProvider serviceProvider = context.HttpContext.RequestServices;

		foreach (var arg in context.ActionArguments.Values)
		{
			if (arg is null) continue;

			Type argType = arg.GetType();

			var validatorType = typeof(IValidator<>).MakeGenericType(argType);

			if (serviceProvider.GetService(validatorType) is not IValidator validator) continue;

			var validationContext = new ValidationContext<object>(arg);

			var validationResult = await validator.ValidateAsync(validationContext);

			if (!validationResult.IsValid)
			{
				context.Result = new BadRequestObjectResult(validationResult.Errors);
				return;
			}

		}

		await next();
	}
}
