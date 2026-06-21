using Microsoft.AspNetCore.Mvc;
using Order.Application.Contracts.Services;
using Order.Application.DTOs.Orders;

namespace Order.Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class OrderController : ControllerBase
	{
		private readonly IOrderService orderService;

		public OrderController(IOrderService productService)
		{
			this.orderService = productService;
		}

		[HttpGet]
		[Route("GetAll")]
		public async Task<IActionResult> Get()
		{
			return Ok(await orderService.GetAll());
		}
		[HttpGet]
		[Route("GetBy/{id}")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await orderService.GetById(id));
		}

		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Add(CreateOrderDTO dTO)
		{
			await orderService.Create(dTO);
			return Ok();
		}

		[HttpPost]
		[Route("Update")]
		public async Task<IActionResult> Update(UpdateOrderDTO dTO)
		{
			await orderService.Update(dTO);
			return Ok();
		}

		[HttpPost]
		[Route("Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await orderService.Delete(id);
			return Ok();
		}
	}
}
