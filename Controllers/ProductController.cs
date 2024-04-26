using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitOfWorkDemo.Core.Models;
using UnitOfWorkDemo.Services.Interfaces;

namespace UnitOfWorkDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		public readonly IProductService _productService;
		public ProductController(IProductService productService)
		{
			_productService = productService;
		}

		/// <summary>
		/// 제품리스트
		/// </summary>
		/// <returns></returns>
		///
		[HttpGet]
		public async Task<IActionResult> GetProductList()
		{
			var productDetailsList = await _productService.GetAllProducts();
			if (productDetailsList == null)
			{
				return NotFound();
			}
			return Ok(productDetailsList);
		}

		[HttpGet("{productId}")]
		public async Task<IActionResult> GetProductById(int productId)
		{
			var productDetails = await _productService.GetProductById(productId);
			if (productDetails == null)
			{
				return Ok(productDetails);
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpPost]
		public async Task<IActionResult> CreateProduct(ProductDetails productDetails)
		{
			var isProductCreated = await _productService.CreateProduct(productDetails);
			if (isProductCreated)
			{
				return Ok(isProductCreated);
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpPut]
		public async Task<IActionResult> UpdateProduct(ProductDetails productDetails)
		{
			if (productDetails != null)
			{
				var isProductCreated = await _productService.UpdateProduct(productDetails);
				if (isProductCreated)
				{
					return Ok(isProductCreated);
				}
				return BadRequest();
			}
			else
			{
				return BadRequest();
			}
		}

		[HttpDelete("{productId}")]
		public async Task<IActionResult> DeleteProduct(int productId)
		{
			var isProductCreated = await _productService.DeleteProduct(productId);
			if (isProductCreated)
			{
				return Ok(isProductCreated);
			}
			else
			{
				return BadRequest();	
			}
		}
    }
}
