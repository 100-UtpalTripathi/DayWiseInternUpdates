using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System;
using System.Collections.Generic;

namespace RequestTrackerApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DepartmentBL departmentBL = new DepartmentBL();
            EmployeeBL employeeBL = new EmployeeBL();

            // Call department business logic functions
            Console.WriteLine("=== Department Business Logic ===");
            Console.WriteLine("Adding departments...");
            Department department1 = new Department() { Name = "IT" };
            int departmentId1 = departmentBL.AddDepartment(department1);
            Console.WriteLine("Department added. ID: " + departmentId1);
            Console.WriteLine("Department added. Name: " + department1.Name);

            Department department2 = new Department() { Name = "HR" };
            int departmentId2 = departmentBL.AddDepartment(department2);
            Console.WriteLine("Department added. ID: " + departmentId2);
            Console.WriteLine("Department added. Name: " + department2.Name);
            Console.WriteLine();
            Console.WriteLine("Changing department name...");
            Department changedDepartment = departmentBL.ChangeDepartmentName("HR", "Human Resources");
            Console.WriteLine("Department name changed successfully: " + changedDepartment.Name);

            // Call employee business logic functions
            Console.WriteLine("\n=== Employee Business Logic ===");
            Console.WriteLine("Adding employees...");
            Employee employee1 = new Employee() 
            { Name = "John Doe", dept = department1 };
            int employeeId1 = employeeBL.AddEmployee(employee1);
            Console.WriteLine("Employee added. ID: " + employeeId1);
            Console.WriteLine("Employee added. Name: " + employee1.Name);
            Console.WriteLine();

            Employee employee2 = new Employee() 
            { Name = "Jane Smith", dept = department2 };
            int employeeId2 = employeeBL.AddEmployee(employee2);
            Console.WriteLine("Employee added. ID: " + employeeId2);
            Console.WriteLine("Employee added. Name: " + employee2.Name);

            // Get employee by ID
            Console.WriteLine("Getting employee by ID...");
            Employee retrievedEmployee = employeeBL.GetEmployeeById(employeeId1);
            Console.WriteLine("Retrieved Employee: " + retrievedEmployee.Name);

            // Get all employees
            Console.WriteLine("\nGetting all employees...");
            List<Employee> allEmployees = employeeBL.GetAllEmployees();
            Console.WriteLine("\nAll Employees:");
            foreach (var emp in allEmployees)
            {
                Console.WriteLine(emp.Name);
            }

            Console.ReadKey();
        }
    }
}
