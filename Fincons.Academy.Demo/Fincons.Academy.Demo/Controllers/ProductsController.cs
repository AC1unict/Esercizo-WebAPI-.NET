using Fincons.Academy.Demo.Models;
using Fincons.Academy.Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fincons.Academy.Demo.Controllers
{
    /// <summary>
    /// https://localhost:7079/api/products
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductRepository productRepository)
        {
            _logger = logger;
            _productRepository = productRepository;
        }

        [HttpGet]
        public IEnumerable<Product> GetProducts([FromServices] IExecutionCounter executionCounter)
        {
            executionCounter.Increment();
            return _productRepository.GetProducts();
        }

        [HttpGet("{productId}")]
        public ActionResult<Product> GetProductById(int productId, [FromServices] IExecutionCounter executionCounter)
        {
            var product = _productRepository.GetById(productId);

            if (product == null)
            {
                return NotFound("Non esiste nessuna risorsa con questo id");
            }

            return Ok(product);
        }

        [HttpPost]
        public Product CreateProduct([FromBody] Product product, [FromServices] IExecutionCounter executionCounter)
        {
            executionCounter.Increment();
            return _productRepository.CreateProduct(product);
        }

        [HttpPut("{productId}")]
        public Product UpdateProduct(int productId, [FromBody] Product product, [FromServices] IExecutionCounter executionCounter)
        {
            executionCounter.Increment();
            return _productRepository.UpdateProduct(product, productId);
        }

        [HttpDelete("{productId}")]
        public void DeleteProduct(int productId, [FromServices] IExecutionCounter executionCounter)
        {
            executionCounter.Increment();
            _productRepository.DeleteProduct(productId);
        }

        [HttpGet("{productId}/caratteristiche")]
        public IEnumerable<Caratterisca> GetCaratteresticheDiUnProdotto(int productId)
        {
            return new List<Caratterisca>();
        }
    }
}
