using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;

namespace RequestTrackerBLLibrary
{
    public class EmployeeBL : IEmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeBL()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public int AddEmployee(Employee employee)
        {
            var result = _employeeRepository.Add(employee);
            if (result == null)
            {
                throw new DuplicateEmployeeIdException();
            }
            return result.Id;
        }

        public Employee GetEmployeeById(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null)
            {
                throw new EmployeeNotFoundException();
            }
            return employee;
        }

        public List<Employee> GetAllEmployees()
        {
            var employees = _employeeRepository.GetAll();
            if (employees == null || employees.Count == 0)
            {
                throw new NoEmployeesFoundException();
            }
            return employees;
        }

        public Employee UpdateEmployee(Employee employee)
        {
            var existingEmployee = _employeeRepository.Get(employee.Id);
            if (existingEmployee == null)
            {
                throw new EmployeeNotFoundException();
            }
            return _employeeRepository.Update(employee);
        }

        public void RemoveEmployee(int id)
        {
            var existingEmployee = _employeeRepository.Get(id);
            if (existingEmployee == null)
            {
                throw new EmployeeNotFoundException();
            }
            _employeeRepository.Delete(id);
        }
    }

    
    
    
}
