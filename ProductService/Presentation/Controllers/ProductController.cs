using Order.Application.Contracts.Services;
using Order.Application.DTOs.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IProductService productService;

		public ProductController(IProductService productService)
		{
			this.productService = productService;
		}

		[HttpGet]
		[Route("GetAll")]
		public async Task<IActionResult> Get()
		{
			return Ok(await productService.GetAll());
		}
		[HttpGet]
		[Route("GetBy/{id}")]
		public async Task<IActionResult> Get(int id)
		{
			return Ok(await productService.GetById(id));
		}

		[HttpPost]
		[Route("Create")]
		public async Task<IActionResult> Add(CreateProductDTO dTO)
		{
			await productService.Create(dTO);
			return Ok();
		}

		[HttpPost]
		[Route("Update")]
		public async Task<IActionResult> Update(UpdateProductDTO dTO)
		{
			await productService.Update(dTO);
			return Ok();
		}

		[HttpPost]
		[Route("Delete/{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await productService.Delete(id);
			return Ok();
		}
	}
}
