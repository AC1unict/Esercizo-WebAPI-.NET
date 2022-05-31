using Fincons.Academy.Demo.Models;

namespace Fincons.Academy.Demo.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productContext;
        private readonly IExecutionCounter _executionCounter;

        public ProductRepository(ProductDbContext productContext, IExecutionCounter executionCounter)
        {
            _productContext = productContext;
            _executionCounter = executionCounter;
        }

        public Product CreateProduct(Product product)
        {
            _executionCounter.Increment();
            _productContext.Products.Add(product);
            _productContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int productId)
        {
            _executionCounter.Increment();
            var productToDelete = _productContext.Products.Find(productId);
            if (productToDelete != null)
            {
                _productContext.Remove(productToDelete);
                _productContext.SaveChanges();
            }
        }

        public Product GetById(int id)
        {
            _executionCounter.Increment();
            return _productContext.Products.Find(id);
        }

        public IEnumerable<Product> GetProducts()
        {
            _executionCounter.Increment();
            return _productContext.Products.ToList();
        }

        public Product UpdateProduct(Product product, int productId)
        {
            _executionCounter.Increment();
            var productToUpdate = _productContext.Products.Find(productId);

            if (productToUpdate != null)
            {
                productToUpdate.Name = product.Name;
                productToUpdate.Price = product.Price;
                productToUpdate.Description = product.Description;
                _productContext.Update(productToUpdate);
                _productContext.SaveChanges();
            }

            return productToUpdate;
        }
    }
}
