
using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingApplicationTests
{
    public class CartServiceTests
    {
        private ICartService _cartService;
        private AbstractRepository<int, Cart> _cartRepository;
        private AbstractRepository<int, Product> _productRepository;

        [SetUp]
        public void Setup()
        {
            _cartRepository = new CartRepository();
            _productRepository = new ProductRepository();
            _cartService = new CartService(_cartRepository, _productRepository);
        }

        [Test]
        public void AddProductToCart_ValidProductIdAndQuantity_ProductAddedToCart()
        {
            // Arrange
            int cartId = 1;
            int productId = 1;
            int quantity = 2;

            // Add a cart to the repository
            _cartRepository.Add(new Cart { Id = cartId, CustomerId = 1 });

            // Add the product to the product repository
            _productRepository.Add(new Product { Id = productId, Name = "Product1", Price = 10.0, QuantityInHand = 100 });

            // Act
            var cart = _cartService.AddProductToCart(cartId, productId, quantity);

            // Assert
            Assert.AreEqual(1, cart.CartItems.Count);
            Assert.AreEqual(productId, cart.CartItems[0].ProductId);
            Assert.AreEqual(quantity, cart.CartItems[0].Quantity);
        }


        [Test]
        public void AddProductToCart_NonExistingCart_ThrowsCartNotFoundException()
        {
            // Arrange
            int cartId = 100;
            int productId = 1;
            int quantity = 2;

            // Act & Assert
            Assert.Throws<CartNotFoundException>(() => _cartService.AddProductToCart(cartId, productId, quantity));
        }

        [Test]
        public void AddProductToCart_NonExistingProduct_ThrowsProductNotFoundException()
        {
            // Arrange
            int cartId = 1;
            int productId = 100;
            int quantity = 2;

            // Add a cart to the repository
            _cartRepository.Add(new Cart { Id = cartId, CustomerId = 1 });

            // Act & Assert
            Assert.Throws<ProductNotFoundException>(() => _cartService.AddProductToCart(cartId, productId, quantity));
        }


        [Test]
        public void RemoveProductFromCart_ValidProductId_ProductRemovedFromCart()
        {
            // Arrange
            int cartId = 1;
            int productId = 1;

            // Add a cart with the product to the repository
            var cart = new Cart { Id = cartId, CustomerId = 1 };
            cart.CartItems.Add(new CartItem { CartId = cartId, ProductId = productId, Quantity = 1 });
            _cartRepository.Add(cart);

            // Act
            var updatedCart = _cartService.RemoveProductFromCart(cartId, productId);

            // Assert
            Assert.AreEqual(0, updatedCart.CartItems.Count);
        }


        [Test]
        public void RemoveProductFromCart_NonExistingProduct_ThrowsProductNotFoundException()
        {
            int cartId = 1;
            int productId = 100;

            // Add a cart with items
            var cart = new Cart { Id = cartId, CustomerId = 1 };
            cart.CartItems.Add(new CartItem { CartId = cartId, ProductId = 1, Quantity = 1 });
            cart.CartItems.Add(new CartItem { CartId = cartId, ProductId = 2, Quantity = 2 });
            _cartRepository.Add(cart);

            // Act & Assert
            Assert.Throws<ProductNotFoundException>(() => _cartService.RemoveProductFromCart(cartId, productId));
        }


        // CalculateShippingCharges
        [Test]
        public void CalculateShippingCharges_TotalValueBelow100_ReturnsShippingCharge100()
        {
            // Arrange
            var cart = new Cart { Id = 1, CustomerId = 1 };
            cart.CartItems.Add(new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 50.0 });

            // Act
            var shippingCharge = _cartService.CalculateShippingCharges(cart);

            // Assert
            Assert.AreEqual(100.0, shippingCharge); // Corrected assertion
        }

        // ApplyDiscounts
        [Test]

        public void ApplyDiscounts_ThreeItemsWithValue1500_Apply5PercentDiscount()
        {
            // Arrange
            var cart = new Cart { Id = 1, CustomerId = 1 };
            cart.CartItems.Add(new CartItem { CartId = 1, ProductId = 1, Quantity = 1, Price = 500.0 });
            cart.CartItems.Add(new CartItem { CartId = 1, ProductId = 2, Quantity = 1, Price = 500.0 });
            cart.CartItems.Add(new CartItem { CartId = 1, ProductId = 3, Quantity = 1, Price = 500.0 });

            // Act
            double discount = _cartService.ApplyDiscounts(cart);

            // Assert
            Assert.AreEqual(75.0, discount); // Ensure correct discount amount is applied
        }





        // ExceedsMaxQuantityLimit
        [Test]
        public void ExceedsMaxQuantityLimit_CartItemQuantityGreaterThan5_ReturnsTrue()
        {
            // Arrange
            var cart = new Cart { Id = 1, CustomerId = 1 };
            var productId = 1;
            var quantity = 6; // Quantity to add

            // Add some existing cart items
            cart.CartItems.Add(new CartItem { CartId = 1, ProductId = productId, Quantity = 3 }); // Existing quantity

            // Act
            var exceedsLimit = _cartService.ExceedsMaxQuantityLimit(cart, productId, quantity);

            // Assert
            Assert.IsTrue(exceedsLimit);
        }
    }
}
