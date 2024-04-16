using System;

namespace GovtRulesEmployeeManagementModelLibrary
{
    /// <summary>
    /// Represents an employee with basic details.
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        public int EmpId { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the designation of the employee.
        /// </summary>
        public string Designation { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the basic salary of the employee.
        /// </summary>
        public double BasicSalary { get; set; }

        /// <summary>
        /// Gets or sets the name of the employer.
        /// </summary>
        public string EmployerName { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the Employee class.
        /// </summary>
        public Employee()
        {
            EmpId = 0;
            Name = string.Empty;
            Department = string.Empty;
            Designation = string.Empty;
            BasicSalary = 0;
        }

        /// <summary>
        /// Initializes a new instance of the Employee class with specified details.
        /// </summary>
        /// <param name="empId">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="department">The department of the employee.</param>
        /// <param name="designation">The designation of the employee.</param>
        /// <param name="basicSalary">The basic salary of the employee.</param>
        public Employee(int empId, string name, string department, string designation, double basicSalary)
        {
            EmpId = empId;
            Name = name;
            Department = department;
            Designation = designation;
            BasicSalary = basicSalary;
        }

        /// <summary>
        /// Builds employee details by taking input from the console.
        /// </summary>
        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please Enter the Employee Id: ");
            EmpId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the Name: ");
            Name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please Enter the Department: ");
            Department = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please Enter the Designation: ");
            Designation = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please Enter the Basic Salary: ");
            BasicSalary = Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Prints the details of the employee.
        /// </summary>
        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id: " + EmpId);
            Console.WriteLine("Employee Name: " + Name);
            Console.WriteLine("Department: " + Department);
            Console.WriteLine("Designation: " + Designation);
            Console.WriteLine("Basic Salary: " + BasicSalary);
        }
    }
}
