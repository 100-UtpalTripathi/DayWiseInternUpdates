using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface ICustomerService
    {
        // Add a new customer
        Customer AddCustomer(Customer customer);

        // Update an existing customer
        Customer UpdateCustomer(Customer customer);

        // Get a customer by their ID
        Customer GetCustomerById(int customerId);

        // Get all customers
        IEnumerable<Customer> GetAllCustomers();

        // Delete a customer by their ID
        void DeleteCustomer(int customerId);

        // Search for customers by name
        IEnumerable<Customer> SearchCustomersByName(string name);

        // Search for customers by age
        IEnumerable<Customer> SearchCustomersByAge(int minAge, int maxAge);
    }
}