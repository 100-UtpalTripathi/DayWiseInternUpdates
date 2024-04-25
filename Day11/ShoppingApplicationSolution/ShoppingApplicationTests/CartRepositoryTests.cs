using NUnit.Framework;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;

namespace ShoppingApplicationTests
{
    public class CartRepositoryTests
    {
        private CartRepository repository;
        private List<Cart> carts;

        [SetUp]
        public void Setup()
        {
            repository = new CartRepository();
            carts = new List<Cart>
            {
                new Cart { Id = 1, CustomerId = 101, Customer = new Customer { Id = 101, Phone = "1234567890", Age = 30 }, CartItems = new List<CartItem>() },
                new Cart { Id = 2, CustomerId = 102, Customer = new Customer { Id = 102, Phone = "0987654321", Age = 25 }, CartItems = new List<CartItem>() }
            };
            foreach (var cart in carts)
            {
                repository.Add(cart);
            }
        }

        [Test]
        public void Add_ValidCart_ReturnsAddedCart()
        {
            // Arrange
            Cart newCart = new Cart { Id = 3, CustomerId = 103, Customer = new Customer { Id = 103, Phone = "9876543210", Age = 35 }, CartItems = new List<CartItem>() };

            // Act
            Cart addedCart = repository.Add(newCart);

            // Assert
            Assert.AreEqual(newCart, addedCart);
            Assert.IsTrue(repository.GetAll().Contains(newCart));
        }

        [Test]
        public void Add_DuplicateCart_ThrowsException()
        {
            // Arrange
            Cart existingCart = new Cart { Id = 1, CustomerId = 101, Customer = new Customer { Id = 101, Phone = "1234567890", Age = 30 }, CartItems = new List<CartItem>() };

            // Assert
            Assert.Throws<DuplicateItemFound>(() => repository.Add(existingCart));
        }

        [Test]
        public void Delete_ExistingCartId_RemovesCart()
        {
            // Arrange
            int cartIdToDelete = 1;

            // Act
            Cart deletedCart = repository.Delete(cartIdToDelete);

            // Assert
            Assert.AreEqual(1, repository.GetAll().Count);
            Assert.IsFalse(repository.GetAll().Contains(deletedCart));
        }

        [Test]
        public void Delete_NonExistingCartId_ThrowsException()
        {
            // Arrange
            int nonExistingCartId = 100;

            // Assert
            Assert.Throws<KeyNotFoundException>(() => repository.Delete(nonExistingCartId));
        }

        [Test]
        public void GetByKey_ExistingCartId_ReturnsCart()
        {
            // Arrange
            int existingCartId = 2;

            // Act
            Cart retrievedCart = repository.GetByKey(existingCartId);

            // Assert
            Assert.IsNotNull(retrievedCart);
            Assert.AreEqual(existingCartId, retrievedCart.Id);
        }

        [Test]
        public void GetByKey_NonExistingCartId_ThrowsException()
        {
            // Arrange
            int nonExistingCartId = 100;

            // Assert
            Assert.Throws<KeyNotFoundException>(() => repository.GetByKey(nonExistingCartId));
        }

        [Test]
        public void Update_ExistingCart_ReturnsUpdatedCart()
        {
            // Arrange
            int existingCartId = 1;
            Cart updatedCart = new Cart { Id = existingCartId, CustomerId = 101, Customer = new Customer { Id = 101, Phone = "1234567890", Age = 30 }, CartItems = new List<CartItem>() };

            // Act
            Cart returnedCart = repository.Update(updatedCart);

            // Assert
            Assert.AreEqual(updatedCart, returnedCart);
            Assert.AreEqual("1234567890", repository.GetByKey(existingCartId).Customer.Phone);
        }

        [Test]
        public void Update_NonExistingCart_ThrowsException()
        {
            // Arrange
            Cart nonExistingCart = new Cart { Id = 100, CustomerId = 100, Customer = new Customer { Id = 100, Phone = "1112223333", Age = 40 }, CartItems = new List<CartItem>() };

            // Assert
            Assert.Throws<KeyNotFoundException>(() => repository.Update(nonExistingCart));
        }
    }
}
