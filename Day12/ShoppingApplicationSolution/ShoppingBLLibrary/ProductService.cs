using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingDALLibrary;
using System;
using System.Collections.Generic;

namespace ShoppingBLLibrary
{
    public class ProductService : IProductService
    {
        private readonly AbstractRepository<int, Product> _productRepository;

        public ProductService(AbstractRepository<int, Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product AddProduct(Product product)
        {
            if (product == null)
            {
                throw new InvalidProductDataException("Product data cannot be null.");
            }

            // Check if the product already exists
            if (_productRepository.GetAll().Any(p => p.Id == product.Id))
            {
                throw new DuplicateProductException($"Product with ID {product.Id} already exists.");
            }

            return _productRepository.Add(product);
        }

        public void DeleteProduct(int productId)
        {
            Product product = _productRepository.GetByKey(productId);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found.");
            }

            _productRepository.Delete(productId);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }

        public Product GetProductById(int productId)
        {
            Product product = _productRepository.GetByKey(productId);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found.");
            }

            return product;
        }

        public IEnumerable<Product> SearchProductsByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidProductDataException("Name cannot be empty.");
            }

            return _productRepository.GetAll().Where(p => p.Name.Contains(name));
        }

        public IEnumerable<Product> SearchProductsByPriceRange(double minPrice, double maxPrice)
        {
            if (minPrice < 0 || maxPrice < 0 || minPrice > maxPrice)
            {
                throw new InvalidProductDataException("Invalid price range.");
            }

            return _productRepository.GetAll().Where(p => p.Price >= minPrice && p.Price <= maxPrice);
        }

        public Product UpdateProduct(Product product)
        {
            if (product == null)
            {
                throw new InvalidProductDataException("Product data cannot be null.");
            }

            Product existingProduct = _productRepository.GetByKey(product.Id);
            if (existingProduct == null)
            {
                throw new ProductNotFoundException($"Product with ID {product.Id} not found.");
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Image = product.Image;
            existingProduct.QuantityInHand = product.QuantityInHand;

            return _productRepository.Update(existingProduct);
        }
    }
}
