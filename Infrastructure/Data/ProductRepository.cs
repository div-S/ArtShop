using Core.Entities;
using Core.Interfaces;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }
        //public async Task<Product> GetProductByIdAsync(int id)
        //{
        //    return await context.Products.FindAsync(id);
        //}

        //public async Task<IReadOnlyList<Product>> GetProductAsync()
        //{
        //    return await context.Products.ToListAsync();
        //}


        public Product GetProductById(int id)
        {
            var product = context.Products.Find(id);

            if (product != null)
            {
                context.Entry(product).Reference(p => p.ProductCategory).Load();
            }

            return product;

            //return context.Products.Include(p => p.ProductCategory).FirstOrDefault(p => p.Id == id);
        }

        public IReadOnlyList<Product> GetProduct()
        {
            var products = context.Products.ToList();

            foreach (var product in products)
            {
                context.Entry(product).Reference(p => p.ProductCategory).Load();
            }

            return products;

            //return context.Products.Include(p => p.ProductCategory).ToList();
        }

        public IReadOnlyList<ProductCategory> GetProductCategories()
        {
            return context.ProductCategories.ToList();
        }
    }
}
