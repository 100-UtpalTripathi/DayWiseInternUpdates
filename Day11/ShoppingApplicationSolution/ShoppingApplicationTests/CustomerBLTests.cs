using ShoppingBLLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using ShoppingDALLibrary;

namespace ShoppingApplicationTests
{
    public class CustomerServiceTests
    {
        private CustomerService _customerService;

        [SetUp]
        public void Setup()
        {
            // Arrange
            var customerRepository = new CustomerRepository();
            _customerService = new CustomerService(customerRepository);
        }

        [Test]
        public void AddCustomer_ValidCustomer_ReturnsAddedCustomer()
        {
            // Arrange
            var customer = new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 };

            // Act
            var addedCustomer = _customerService.AddCustomer(customer);

            // Assert
            Assert.AreEqual(customer, addedCustomer);
        }

        [Test]
        public void AddCustomer_NullCustomer_ThrowsInvalidCustomerDataException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidCustomerDataException>(() => _customerService.AddCustomer(null));
        }

        [Test]
        public void AddCustomer_DuplicateCustomerId_ThrowsDuplicateCustomerException()
        {
            // Arrange
            var customer = new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 };
            _customerService.AddCustomer(customer);

            // Act & Assert
            Assert.Throws<DuplicateCustomerException>(() => _customerService.AddCustomer(customer));
        }

        [Test]
        public void DeleteCustomer_ExistingCustomerId_RemovesCustomer()
        {
            // Arrange
            var customer = new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 };
            _customerService.AddCustomer(customer);

            // Act
            _customerService.DeleteCustomer(customer.Id);

            // Assert
            Assert.Throws<CustomerNotFoundException>(() => _customerService.GetCustomerById(customer.Id));
        }

        [Test]
        public void DeleteCustomer_NonExistingCustomerId_ThrowsCustomerNotFoundException()
        {
            // Arrange & Act & Assert
            Assert.Throws<CustomerNotFoundException>(() => _customerService.DeleteCustomer(100));
        }

        [Test]
        public void GetAllCustomers_ReturnsAllCustomers()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 },
                new Customer { Id = 2, Name = "Jane Smith", Phone = "0987654321", Age = 25 }
            };

            foreach (var customer in customers)
            {
                _customerService.AddCustomer(customer);
            }

            // Act
            var retrievedCustomers = _customerService.GetAllCustomers();

            // Assert
            CollectionAssert.AreEquivalent(customers, retrievedCustomers);
        }


        [Test]
        public void GetCustomerById_ExistingCustomerId_ReturnsCustomer()
        {
            // Arrange
            var customer = new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 };
            _customerService.AddCustomer(customer);

            // Act
            var retrievedCustomer = _customerService.GetCustomerById(customer.Id);

            // Assert
            Assert.AreEqual(customer, retrievedCustomer);
        }

        [Test]
        public void GetCustomerById_NonExistingCustomerId_ThrowsCustomerNotFoundException()
        {
            // Arrange & Act & Assert
            Assert.Throws<CustomerNotFoundException>(() => _customerService.GetCustomerById(100));
        }

        [Test]

        public void SearchCustomersByName_ExistingName_ReturnsMatchingCustomers()
        {
            // Arrange
            var customer1 = new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 };
            var customer2 = new Customer { Id = 2, Name = "Jane Smith", Phone = "0987654321", Age = 25 };
            _customerService.AddCustomer(customer1);
            _customerService.AddCustomer(customer2);

            // Act
            var searchResults = _customerService.SearchCustomersByName("John");

            // Assert
            Assert.IsTrue(searchResults.Contains(customer1));
        }


        [Test]
        public void SearchCustomersByName_NonExistingName_ReturnsEmptyCollection()
        {
            // Arrange
            var customer = new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 };
            _customerService.AddCustomer(customer);

            // Act
            var searchResults = _customerService.SearchCustomersByName("Jane");

            // Assert
            Assert.IsEmpty(searchResults);
        }

        [Test]
        public void SearchCustomersByAge_ValidRange_ReturnsMatchingCustomers()
        {
            // Arrange
            var customer1 = new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 };
            var customer2 = new Customer { Id = 2, Name = "Jane Smith", Phone = "0987654321", Age = 25 };
            _customerService.AddCustomer(customer1);
            _customerService.AddCustomer(customer2);

            // Act
            var searchResults = _customerService.SearchCustomersByAge(20, 29);

            // Assert
            Assert.IsTrue(searchResults.Any(c => c.Id == customer2.Id)); // Check if customer2 is in the searchResults
        }


        [Test]
        public void SearchCustomersByAge_InvalidRange_ThrowsInvalidCustomerDataException()
        {
            // Arrange & Act & Assert
            Assert.Throws<InvalidCustomerDataException>(() => _customerService.SearchCustomersByAge(30, 20));
        }

        [Test]
        public void UpdateCustomer_ExistingCustomer_ReturnsUpdatedCustomer()
        {
            // Arrange
            var customer = new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 };
            _customerService.AddCustomer(customer);

            // Act
            customer.Name = "Jane Smith";
            var updatedCustomer = _customerService.UpdateCustomer(customer);

            // Assert
            Assert.AreEqual(customer, updatedCustomer);
            Assert.AreEqual("Jane Smith", updatedCustomer.Name);
        }

        [Test]
        public void UpdateCustomer_NonExistingCustomer_ThrowsCustomerNotFoundException()
        {
            // Arrange
            var customer = new Customer { Id = 1, Name = "John Doe", Phone = "1234567890", Age = 30 };

            // Act & Assert
            Assert.Throws<CustomerNotFoundException>(() => _customerService.UpdateCustomer(customer));
        }


    }

}
