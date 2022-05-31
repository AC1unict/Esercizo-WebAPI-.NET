using Fincons.Academy.Demo.Models;

namespace Fincons.Academy.Demo.Services
{
    public interface IProductRepository
    {
        Product GetById(int id);

        IEnumerable<Product> GetProducts();

        Product CreateProduct(Product product);

        Product UpdateProduct(Product product, int productId);

        void DeleteProduct(int productId);
    }
}
