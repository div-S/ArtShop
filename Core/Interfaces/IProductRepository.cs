using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        //Task<Product> GetProductByIdAsync(int id);

        //Task<IReadOnlyList<Product>> GetProductAsync();

        Product GetProductById(int id);

        IReadOnlyList<Product> GetProduct();

        IReadOnlyList<ProductCategory> GetProductCategories();

    }
}
