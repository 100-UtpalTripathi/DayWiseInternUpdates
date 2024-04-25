using ShoppingModelLibrary;
using System.Collections.Generic;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        // Add a new product
        Product AddProduct(Product product);

        // Update an existing product
        Product UpdateProduct(Product product);

        // Get a product by its ID
        Product GetProductById(int productId);

        // Get all products
        IEnumerable<Product> GetAllProducts();

        // Delete a product by its ID
        void DeleteProduct(int productId);

        // Search products by name
        IEnumerable<Product> SearchProductsByName(string name);

        // Search products by price range
        IEnumerable<Product> SearchProductsByPriceRange(double minPrice, double maxPrice);
    }
}
