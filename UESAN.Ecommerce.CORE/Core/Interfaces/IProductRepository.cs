using UESAN.Ecommerce.CORE.Core.Entities;

namespace UESAN.Ecommerce.CORE.Core.Interfaces
{
    public interface IProductRepository
    {
        Task DeleteProduct(int id);
        Task DeleteProductLogic(int id);
        Task<IEnumerable<Product>> GetProducts();
        IEnumerable<Product> GetProductsAll();
        Task<Product?> GetProductById(int id);
        Task<int> InsertProduct(Product product);
        Task UpdateProduct(Product product);
    }
}