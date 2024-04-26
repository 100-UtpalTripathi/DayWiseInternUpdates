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

            if (product.QuantityInHand < quantity)
            {
                throw new InsufficientQuantityException($"Product with ID {productId} has insufficient quantity in hand.");
            }

            if (ExceedsMaxQuantityLimit(cart, productId, quantity))
            {
                throw new MaxQuantityExceededException($"Adding product to cart exceeds maximum quantity limit.");
            }

            // checking if product already exists in teh card... if yes, then update the quantity
            CartItem existingItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
            }
            else
            {
                cart.CartItems.Add(new CartItem(cartId, productId, quantity, product.Price, 0, DateTime.Now.AddDays(7)));
            }

            // Updating product quantity in hand
            product.QuantityInHand -= quantity;
            _productRepository.Update(product);

            return _cartRepository.Update(cart);
        }


        public Cart RemoveProductFromCart(int cartId, int productId)
        {
            Cart cart = _cartRepository.GetByKey(cartId);
            if (cart == null)
            {
                throw new CartNotFoundException($"Cart with ID {cartId} not found.");
            }

            CartItem cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found in cart.");
            }

            Product product = _productRepository.GetByKey(productId);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found.");
            }

            product.QuantityInHand += cartItem.Quantity;
            _productRepository.Update(product);

            cart.CartItems.Remove(cartItem);

            return _cartRepository.Update(cart);
        }

        public void IncreaseCartItemQuantity(Cart cart, int productId, int quantity)
        {
            CartItem cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem != null)
            {
                Product product = _productRepository.GetByKey(productId);
                if (product != null)
                {
                    int totalQuantity = cartItem.Quantity + quantity;

                    if (totalQuantity > 5)
                    {
                        throw new MaxQuantityExceededException($"Exceeds maximum quantity limit for product {productId}.");
                    }

           
                    cartItem.Quantity += quantity;

                
                    product.QuantityInHand -= quantity;

           
                    _productRepository.Update(product);
                    _cartRepository.Update(cart);
                }
            }
        }

        public void DecreaseCartItemQuantity(Cart cart, int productId, int decreaseQuantity)
        {
            CartItem cartItem = cart.CartItems.FirstOrDefault(item => item.ProductId == productId);
            if (cartItem == null)
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found in cart.");
            }

            if (decreaseQuantity <= 0)
            {
                throw new ArgumentException("Quantity to decrease must be greater than zero.");
            }

            if (decreaseQuantity > cartItem.Quantity)
            {
                throw new ArgumentOutOfRangeException("Quantity to decrease exceeds the current quantity in cart.");
            }

            Product product = _productRepository.GetByKey(productId);
            if (product == null)
            {
                throw new ProductNotFoundException($"Product with ID {productId} not found.");
            }

            cartItem.Quantity -= decreaseQuantity;
            if (cartItem.Quantity == 0)
            {
                cart.CartItems.Remove(cartItem); // Remove the cart item if its quantity becomes zero
            }

            product.QuantityInHand += decreaseQuantity;
            _productRepository.Update(product);

            _cartRepository.Update(cart);
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
