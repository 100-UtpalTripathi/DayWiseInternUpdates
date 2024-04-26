using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLLibrary
{
    public class CartService : ICartService
    {
        private readonly AbstractRepository<int, Cart> _cartRepository;
        private readonly AbstractRepository<int, Product> _productRepository;

        public CartService(AbstractRepository<int, Cart> cartRepository, AbstractRepository<int, Product> productRepository)
        {
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public Cart AddProductToCart(int cartId, int productId, int quantity)
        {
           
            Cart cart = _cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                throw new CartNotFoundException($"Cart with ID {cartId} not found.");
            }

            Product product = _productRepository.GetByKey(productId);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found.");
            }
            

           // Checking if adding the product exceeds the maximum quantity limit
            if (ExceedsMaxQuantityLimit(cart, productId, quantity))
            {
                throw new MaxQuantityExceededException($"Adding product to cart exceeds maximum quantity limit.");
            }

            // Add the product to the cart
            cart.CartItems.Add(new CartItem(cartId, productId, quantity, product.Price, 0, DateTime.Now.AddDays(7)));

            return _cartRepository.Update(cart);
        }

        public Cart RemoveProductFromCart(int cartId, int productId)
        {
            // Check if cart exists
            Cart cart = _cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                throw new CartNotFoundException($"Cart with ID {cartId} not found.");
            }

            // Check if the product exists in the cart
            CartItem cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found in cart.");
            }

            // Remove the product from the cart
            cart.CartItems.Remove(cartItem);

            return _cartRepository.Update(cart);
        }

        public Cart GetCartById(int cartId)
        {
            Cart cart = _cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                throw new CartNotFoundException($"Cart with ID {cartId} not found.");
            }

            return cart;
        }

        public IEnumerable<Cart> GetAllCarts()
        {
            return _cartRepository.GetAll();
        }

        public double CalculateShippingCharges(Cart cart)
        {
  
            double totalPurchaseValue = 0;
            foreach (var cartItem in cart.CartItems)
            {
                totalPurchaseValue += cartItem.Price * cartItem.Quantity;
            }

           
            if (totalPurchaseValue < 100)
            {
                return 100;
            }
            else
            {
                return 0;
            }
        }

        public double ApplyDiscounts(Cart cart)
        {
            double totalValue = cart.CartItems.Sum(item => item.Price * item.Quantity);

            if (cart.CartItems.Count == 3 && totalValue >= 1500)
            {
                return totalValue * 0.05;
            }
            else
            {
                return 0; 
            }
        }

        public bool ExceedsMaxQuantityLimit(Cart cart, int productId, int quantity)
        {
            int currentQuantity = cart.CartItems.Where(item => item.ProductId == productId).Sum(item => item.Quantity);
            return currentQuantity + quantity > 5; 
        }
    }
}
