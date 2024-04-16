using System;

namespace RequestTrackerModelLibrary
{
    /// <summary>
    /// Represents an employee.
    /// </summary>
    public class Employee : IClientInteraction, IInternalCompanyWorking
    {
        /// <summary>
        /// Gets or sets the department of the employee.
        /// </summary>
        public Department EmployeeDepartment { get; set; }

        private int age;
        private DateTime dob;

        /// <summary>
        /// Gets or sets the employee ID.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets the age of the employee.
        /// </summary>
        public int Age
        {
            get { return age; }
        }

        /// <summary>
        /// Gets or sets the date of birth of the employee.
        /// </summary>
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }

        /// <summary>
        /// Gets or sets the salary of the employee.
        /// </summary>
        public double Salary { get; set; }

        /// <summary>
        /// Gets or sets the type of the employee.
        /// </summary>
        public string Type { get; set; } = string.Empty;

        /// <summary>
        /// Initializes a new instance of the Employee class.
        /// </summary>
        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
            Type = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the Employee class with specified details.
        /// </summary>
        /// <param name="id">The employee ID.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="dateOfBirth">The date of birth of the employee.</param>
        public Employee(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        /// <summary>
        /// Builds employee details by taking input from the console.
        /// </summary>
        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please Enter the Name: ");
            Name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("Please Enter the Date of birth: ");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
        }

        /// <summary>
        /// Prints the details of the employee.
        /// </summary>
        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of birth : " + DateOfBirth);
            Console.WriteLine("Employee Age : " + Age);
        }

        /// <summary>
        /// Simulates getting an order by the employee.
        /// </summary>
        public void GetOrder()
        {
            Console.WriteLine("Order fetched by " + Name);
        }

        /// <summary>
        /// Simulates getting a payment by the employee.
        /// </summary>
        public void GetPayment()
        {
            Console.WriteLine("Get the payment as per terms");
        }

        /// <summary>
        /// Raises a request.
        /// </summary>
        public void RaiseRequest()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Closes a request.
        /// </summary>
        public void CloseRequest()
        {
            throw new NotImplementedException();
        }
    }
}
