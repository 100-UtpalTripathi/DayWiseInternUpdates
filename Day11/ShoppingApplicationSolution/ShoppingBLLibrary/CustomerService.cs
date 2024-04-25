using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingDALLibrary;

namespace ShoppingBLLibrary
{
    public class CustomerService : ICustomerService
    {
        private readonly AbstractRepository<int, Customer> _customerRepository;

        public CustomerService(AbstractRepository<int, Customer> repository)
        {
            _customerRepository = repository;
        }

        public Customer AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new InvalidCustomerDataException("Customer data cannot be null.");
            }

            // Check if the customer already exists
            if (_customerRepository.GetAll().Any(c => c.Id == customer.Id))
            {
                throw new DuplicateCustomerException("Customer with ID {customer.Id} already exists.");
            }

            return _customerRepository.Add(customer);
        }

        public void DeleteCustomer(int customerId)
        {
            Customer customer = _customerRepository.GetByKey(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customerId} not found.");
            }

            _customerRepository.Delete(customerId);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerRepository.GetAll();
        }

        public Customer GetCustomerById(int customerId)
        {
            Customer customer = _customerRepository.GetByKey(customerId);
            if (customer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customerId} not found.");
            }

            return customer;
        }

        public IEnumerable<Customer> SearchCustomersByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new InvalidCustomerDataException("Name cannot be empty.");
            }

            return _customerRepository.GetAll().Where(c => c.Name.Contains(name));
        }

        public IEnumerable<Customer> SearchCustomersByAge(int minAge, int maxAge)
        {
            if (minAge < 0 || maxAge < 0 || minAge > maxAge)
            {
                throw new InvalidCustomerDataException("Invalid age range.");
            }

            return _customerRepository.GetAll().Where(c => c.Age >= minAge && c.Age <= maxAge);
        }

        public Customer UpdateCustomer(Customer customer)
        {
            if (customer == null)
            {
                throw new InvalidCustomerDataException("Customer data cannot be null.");
            }

            Customer existingCustomer = _customerRepository.GetByKey(customer.Id);
            if (existingCustomer == null)
            {
                throw new CustomerNotFoundException($"Customer with ID {customer.Id} not found.");
            }

            existingCustomer.Name = customer.Name;
            existingCustomer.Phone = customer.Phone;
            existingCustomer.Age = customer.Age;

            return _customerRepository.Update(existingCustomer);
        }
    }
}
