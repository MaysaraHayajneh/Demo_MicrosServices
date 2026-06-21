using Customer.Application.Contracts.Services;
using Customer.Application.DTOs.Customers;
using Microsoft.AspNetCore.Mvc;

namespace Customer.Presentation.Controllers 
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService customerService;

		public CustomerController(ICustomerService productService)
		{
			this.customerService = productService;
		}

		[HttpGet]
		[Route("GetAll")]
		public async Task<IActionResult> Get()
		{
			return Ok(await customerService.GetAll());
		}
		[HttpGet]
		[Route("GetBy/{id}")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await customerService.GetById(id));
		}

		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Add(CreateCustomerDTO dTO)
		{
			await customerService.Create(dTO);
			return Ok();
		}

		[HttpPost]
		[Route("Update")]
		public async Task<IActionResult> Update(UpdateCustomerDTO dTO)
		{
			await customerService.Update(dTO);
			return Ok();
		}

		[HttpPost]
		[Route("Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await customerService.Delete(id);
			return Ok();
		}
	}
}
