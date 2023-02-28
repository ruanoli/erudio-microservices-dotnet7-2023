using GeekShpping.ProductAPI.Data.ValueObjects;
using GeekShpping.ProductAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeekShpping.ProductAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new ArgumentException(nameof(productRepository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductVO>>> FindAllProducts() => 
            Ok( await _productRepository.FindAll());

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductVO>> FindById(long id)
        {
            var product = await _productRepository.FindById(id);

            if(product.Id <= 0) return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductVO>> CreateProduct(ProductVO vo)
        {
            if (vo == null) return BadRequest();

            var product = await _productRepository.CreateProduct(vo);

            return Ok(product);
        }

        [HttpPut]
        public async Task<ActionResult<ProductVO>> UpdateProduct(ProductVO vo)
        {
            if(vo == null) return BadRequest();

            var product = await _productRepository.UpdateProduct(vo);

            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var status = await _productRepository.DeleteProduct(id);

            if(!status) return BadRequest();

            return Ok(status);
        }
    }
}
