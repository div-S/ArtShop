using Core.Entities;
using System.Text.Json;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {
        public static async Task SeedAsync(StoreContext context)
        {
            if (!context.ProductCategories.Any())
            {
                var brandsData = File.ReadAllText("../Infrastructure/Data/SeedData/categories.json");
                var brands = JsonSerializer.Deserialize<List<ProductCategory>>(brandsData);

                context.ProductCategories.AddRange(brands);
            }

            if (!context.Products.Any())
            {
                var productData = File.ReadAllText("../Infrastructure/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productData);

                context.Products.AddRange(products);
            }

            if(context.ChangeTracker.HasChanges())
                await context.SaveChangesAsync();
        }
    }
}
