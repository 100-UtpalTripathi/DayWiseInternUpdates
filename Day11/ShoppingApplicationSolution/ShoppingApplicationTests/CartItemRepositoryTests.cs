
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingApplicationTests
{
    public class CartItemRepositoryTests
    {
        private ICartItemRepository repository;
        private List<CartItem> cartItems;

        [SetUp]
        public void Setup()
        {
            repository = new CartItemRepository();
            // Initialize repository with some initial data if needed
            cartItems = new List<CartItem>
            {
                new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.5, PriceExpiryDate = DateTime.Today.AddDays(7) },
                new CartItem { CartId = 1, ProductId = 102, Quantity = 1, Price = 5.99, Discount = 0.5, PriceExpiryDate = DateTime.Today.AddDays(5) }
            };
            foreach (var item in cartItems)
            {
                repository.Add(item);
            }
        }

        [Test]
        public void Add_ValidCartItem_ReturnsAddedCartItem()
        {
            // Arrange
            CartItem newCartItem = new CartItem { CartId = 2, ProductId = 201, Quantity = 3, Price = 8.49, Discount = 2.0, PriceExpiryDate = DateTime.Today.AddDays(10) };

            // Act
            CartItem addedCartItem = repository.Add(newCartItem);

            // Assert
            Assert.AreEqual(newCartItem, addedCartItem);
            Assert.IsTrue(repository.GetAll().Contains(newCartItem));
        }
        [Test]
        public void Add_DuplicateCartItem_ThrowsException()
        {
            // Arrange
            CartItem existingCartItem = new CartItem { CartId = 1, ProductId = 101, Quantity = 2, Price = 10.99, Discount = 1.5, PriceExpiryDate = DateTime.Today.AddDays(7) };

            // Assert
            Assert.Throws<DuplicateItemFound>(() => repository.Add(existingCartItem));
        }

        [Test]
        public void GetAll_ReturnsAllCartItems()
        {
            // Act
            ICollection<CartItem> retrievedItems = repository.GetAll();

            // Assert
            Assert.AreEqual(cartItems.Count, retrievedItems.Count);
            foreach (var item in cartItems)
            {
                Assert.IsTrue(retrievedItems.Contains(item));
            }
        }

        [Test]
        public void Delete_ExistingCartItem_RemovesCartItem()
        {
            // Arrange
            int cartIdToDelete = 1;
            int productIdToDelete = 101;

            // Act
            CartItem deletedCartItem = repository.Delete(cartIdToDelete, productIdToDelete);

            // Assert
            Assert.AreEqual(cartItems.Count - 1, repository.GetAll().Count);
            Assert.IsFalse(repository.GetAll().Contains(deletedCartItem));
        }

        [Test]
        public void Delete_NonExistingCartItem_ThrowsException()
        {
            // Arrange
            int nonExistingCartId = 100;
            int nonExistingProductId = 999;

            // Assert
            Assert.Throws<KeyNotFoundException>(() => repository.Delete(nonExistingCartId, nonExistingProductId));
        }

        [Test]
        public void Update_ExistingCartItem_ReturnsUpdatedCartItem()
        {
            // Arrange
            int existingCartId = 1;
            int existingProductId = 101;
            CartItem updatedCartItem = new CartItem { CartId = existingCartId, ProductId = existingProductId, Quantity = 5, Price = 12.99, Discount = 2.5, PriceExpiryDate = DateTime.Today.AddDays(15) };

            // Act
            CartItem returnedCartItem = repository.Update(updatedCartItem);

            // Assert
            Assert.AreEqual(updatedCartItem, returnedCartItem);
            Assert.AreEqual(5, repository.GetByKey(existingCartId, existingProductId).Quantity);
        }

        [Test]
        public void Update_NonExistingCartItem_ThrowsException()
        {
            // Arrange
            CartItem nonExistingCartItem = new CartItem { CartId = 100, ProductId = 999, Quantity = 3, Price = 9.99, Discount = 1.0, PriceExpiryDate = DateTime.Today.AddDays(20) };

            // Assert
            Assert.Throws<KeyNotFoundException>(() => repository.Update(nonExistingCartItem));
        }

        [Test]
        public void GetByKey_ExistingCartItem_ReturnsCartItem()
        {
            // Arrange
            int existingCartId = 1;
            int existingProductId = 102;

            // Act
            CartItem retrievedCartItem = repository.GetByKey(existingCartId, existingProductId);

            // Assert
            Assert.IsNotNull(retrievedCartItem);
            Assert.AreEqual(existingCartId, retrievedCartItem.CartId);
            Assert.AreEqual(existingProductId, retrievedCartItem.ProductId);
        }

        [Test]
        public void GetByKey_NonExistingCartItem_ThrowsException()
        {
            // Arrange
            int nonExistingCartId = 100;
            int nonExistingProductId = 999;

            // Assert
            Assert.Throws<KeyNotFoundException>(() => repository.GetByKey(nonExistingCartId, nonExistingProductId));
        }
    }
}
