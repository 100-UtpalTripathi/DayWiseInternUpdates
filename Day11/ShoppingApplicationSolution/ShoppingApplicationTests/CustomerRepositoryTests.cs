using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;

namespace ShoppingApplicationTests
{
    public class CustomerRepositoryTests
    {
        private CustomerRepository repository;

        [SetUp]
        public void Setup()
        {
            repository = new CustomerRepository();
            // Initialize repository with some initial data if needed
            repository.Add(new Customer(1, "Somu", "1234567890", 30));
            repository.Add(new Customer(2, "Ramu", "9876543210", 25));
        }

        [Test]
        public void Add_ValidCustomer_ReturnsAddedCustomer()
        {
            // Arrange
            Customer newCustomer = new Customer(3, "Somu", "4561237890", 35);

            // Act
            Customer addedCustomer = repository.Add(newCustomer);

            // Assert
            Assert.AreEqual(newCustomer, addedCustomer);
            Assert.IsTrue(repository.GetAll().Contains(newCustomer));
        }

        [Test]
        public void Add_DuplicateCustomer_ThrowsException()
        {
            // Arrange
            Customer existingCustomer = new Customer(1, "Somu", "1234567890", 30);

            // Assert
            Assert.Throws<DuplicateItemFoundException>(() => repository.Add(existingCustomer));
        }

        [Test]
        public void Delete_ExistingCustomerId_RemovesCustomer()
        {
            // Arrange
            int customerIdToDelete = 1;

            // Act
            Customer deletedCustomer = repository.Delete(customerIdToDelete);

            // Assert
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsFalse(repository.GetAll().Contains(deletedCustomer));
        }

        [Test]
        public void Delete_NonExistingCustomerId_ThrowsException()
        {
            // Arrange
            int nonExistingCustomerId = 100;

            // Assert
            Assert.Throws<NoItemWithGivenIdException>(() => repository.Delete(nonExistingCustomerId));
        }

        [Test]
        public void GetByKey_ExistingCustomerId_ReturnsCustomer()
        {
            // Arrange
            int existingCustomerId = 2;

            // Act
            Customer retrievedCustomer = repository.GetByKey(existingCustomerId);

            // Assert
            Assert.IsNotNull(retrievedCustomer);
            Assert.AreEqual(existingCustomerId, retrievedCustomer.Id);
        }

        [Test]
        public void GetByKey_NonExistingCustomerId_ThrowsException()
        {
            // Arrange
            int nonExistingCustomerId = 100;

            // Assert
            Assert.Throws<NoItemWithGivenIdException>(() => repository.GetByKey(nonExistingCustomerId));
        }

        [Test]
        public void Update_ExistingCustomer_ReturnsUpdatedCustomer()
        {
            // Arrange
            int existingCustomerId = 1;
            Customer updatedCustomer = new Customer(existingCustomerId, "Somu Op", "9999999999", 40);

            // Act
            Customer returnedCustomer = repository.Update(updatedCustomer);

            // Assert
            Assert.AreEqual(updatedCustomer, returnedCustomer);
            Assert.AreEqual("9999999999", repository.GetByKey(existingCustomerId).Phone);
            Assert.AreEqual(40, repository.GetByKey(existingCustomerId).Age);
        }

        [Test]
        public void Update_NonExistingCustomer_ThrowsException()
        {
            // Arrange
            Customer nonExistingCustomer = new Customer(100, "Somu", "1231231234", 50);

            // Assert
            Assert.Throws<NoItemWithGivenIdException>(() => repository.Update(nonExistingCustomer));
        }
    }
}
