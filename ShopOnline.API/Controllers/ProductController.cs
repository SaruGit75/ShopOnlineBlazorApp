using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Extensions;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _productRepository.GetItemsAsync();
                var productCategories = await _productRepository.GetCategoriesAsync();


                if (products == null || productCategories == null)
                    return NotFound();
                else
                {
                    var productsDto = products.ConvertToDto(productCategories);

                    return Ok(productsDto);
                }

            }
            catch (Exception exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data from th db!.");
            }
        } 
    }
}
