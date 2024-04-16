using System;

namespace RequestTrackerModelLibrary
{
    /// <summary>
    /// Represents a permanent employee.
    /// </summary>
    public class PermanentEmployee : Employee
    {
        /// <summary>
        /// Initializes a new instance of the PermanentEmployee class.
        /// </summary>
        public PermanentEmployee()
        {
            Type = "PermanentEmployee";
        }

        /// <summary>
        /// Initializes a new instance of the PermanentEmployee class with specified details.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="dateOfBirth">The date of birth of the employee.</param>
        /// <param name="salary">The salary of the employee.</param>
        public PermanentEmployee(int id, string name, DateTime dateOfBirth, double salary) : base(id, name, dateOfBirth)
        {
            Type = "PermanentEmployee";
            Salary = salary;
        }

        /// <summary>
        /// Builds employee details by taking input from the console, including the basic salary.
        /// </summary>
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            Console.WriteLine("Please enter the Basic Salary");
            Salary = Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Prints the details of the permanent employee, including the salary.
        /// </summary>
        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine("Employee Salary : Rs." + Salary);
        }

        /// <summary>
        /// Executes a special method available only to permanent employees.
        /// </summary>
        public void SpecialPermanentMethod()
        {
            Console.WriteLine("Special permanent method");
        }

        /// <summary>
        /// Returns a string that represents the current PermanentEmployee object.
        /// </summary>
        /// <returns>A string that represents the current PermanentEmployee object.</returns>
        public override string ToString()
        {
            return base.ToString() + "\nSalary : " + Salary;
        }
    }
}
