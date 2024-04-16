using System;

namespace RequestTrackerModelLibrary
{
    /// <summary>
    /// Represents a contract employee.
    /// </summary>
    public class ContractEmployee : Employee
    {
        /// <summary>
        /// Gets or sets the wages per day for the contract employee.
        /// </summary>
        public double WagesPerDay { get; set; }

        /// <summary>
        /// Initializes a new instance of the ContractEmployee class.
        /// </summary>
        public ContractEmployee()
        {
            Type = "ContractEmployee";
        }

        /// <summary>
        /// Initializes a new instance of the ContractEmployee class with specified details.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="dateOfBirth">The date of birth of the employee.</param>
        /// <param name="wagesPerDay">The wages per day for the contract employee.</param>
        public ContractEmployee(int id, string name, DateTime dateOfBirth, double wagesPerDay) : base(id, name, dateOfBirth)
        {
            Type = "ContractEmployee";
            WagesPerDay = wagesPerDay;
            CalculateSalary();
        }

        /// <summary>
        /// Builds employee details by taking input from the console, including the wages per day.
        /// </summary>
        public override void BuildEmployeeFromConsole()
        {
            base.BuildEmployeeFromConsole();
            Console.WriteLine("Please enter the Per Day Wage");
            WagesPerDay = Convert.ToDouble(Console.ReadLine());
            CalculateSalary();
        }

        private void CalculateSalary()
        {
            Salary = WagesPerDay * 30;
        }

        /// <summary>
        /// Prints the details of the contract employee, including the wages per day.
        /// </summary>
        public override void PrintEmployeeDetails()
        {
            base.PrintEmployeeDetails();
            Console.WriteLine("Wages/Day : " + WagesPerDay);
        }

        /// <summary>
        /// Returns a string that represents the current ContractEmployee object.
        /// </summary>
        /// <returns>A string that represents the current ContractEmployee object.</returns>
        public override string ToString()
        {
            return base.ToString() + "\nWages/Day : " + WagesPerDay;
        }
    }
}
