
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;

namespace ShoppingApplicationTests
{
    public class ProductRepositoryTests
    {
        private ProductRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new ProductRepository();
            // Initialize repository with some initial data if needed
            repository.Add(new Product(1, 10.0, "Product1", 100));
            repository.Add(new Product(2, 20.0, "Product2", 200));
        }

        [Test]
        public void Add_ValidProduct_ReturnsAddedProduct()
        {
            // Arrange
            Product newProduct = new Product(3, 30.0, "Product3", 300);

            // Act
            Product addedProduct = repository.Add(newProduct);

            // Assert
            Assert.AreEqual(newProduct, addedProduct);
            Assert.IsTrue(repository.GetAll().Contains(newProduct));
        }

        [Test]
        public void Add_DuplicateProduct_ThrowsException()
        {
            // Arrange
            Product existingProduct = new Product(1, 10.0, "Product1", 100);

            // Assert
            Assert.Throws<DuplicateItemFoundException>(() => repository.Add(existingProduct));
        }

        [Test]
        public void Delete_ExistingProductId_RemovesProduct()
        {
            // Arrange
            int productIdToDelete = 1;

            // Act
            Product deletedProduct = repository.Delete(productIdToDelete);

            // Assert
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsFalse(repository.GetAll().Contains(deletedProduct));
        }

        [Test]
        public void Delete_NonExistingProductId_ThrowsException()
        {
            // Arrange
            int nonExistingProductId = 100;

            // Assert
            Assert.Throws<NoItemWithGivenIdException>(() => repository.Delete(nonExistingProductId));
        }

        [Test]
        public void GetByKey_ExistingProductId_ReturnsProduct()
        {
            // Arrange
            int existingProductId = 2;

            // Act
            Product retrievedProduct = repository.GetByKey(existingProductId);

            // Assert
            Assert.IsNotNull(retrievedProduct);
            Assert.AreEqual(existingProductId, retrievedProduct.Id);
        }

        [Test]
        public void GetByKey_NonExistingProductId_ThrowsException()
        {
            // Arrange
            int nonExistingProductId = 100;

            // Assert
            Assert.Throws<NoItemWithGivenIdException>(() => repository.GetByKey(nonExistingProductId));
        }

        [Test]
        public void Update_ExistingProduct_ReturnsUpdatedProduct()
        {
            // Arrange
            int existingProductId = 1;
            Product updatedProduct = new Product(existingProductId, 15.0, "UpdatedProduct", 150);

            // Act
            Product returnedProduct = repository.Update(updatedProduct);

            // Assert
            Assert.AreEqual(updatedProduct, returnedProduct);
            Assert.AreEqual("UpdatedProduct", repository.GetByKey(existingProductId).Name);
            Assert.AreEqual(15.0, repository.GetByKey(existingProductId).Price);
            Assert.AreEqual(150, repository.GetByKey(existingProductId).QuantityInHand);
        }

        [Test]
        public void Update_NonExistingProduct_ThrowsException()
        {
            // Arrange
            Product nonExistingProduct = new Product(100, 100.0, "NonExistingProduct", 1000);

            // Assert
            Assert.Throws<NoItemWithGivenIdException>(() => repository.Update(nonExistingProduct));
        }
    }
}
