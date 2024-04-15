namespace RequestTrackerModelLibrary
{
    /// <summary>
    /// Represents an employee entity.
    /// </summary>
    public class Employee
    {
        int age;
        DateTime dob;

        /// <summary>
        /// Gets or sets the ID of the employee.
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
            get
            {
                return age;
            }
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
        /// Initializes a new instance of the <see cref="Employee"/> class.
        /// </summary>
        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Employee"/> class with specified parameters.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <param name="name">The name of the employee.</param>
        /// <param name="dateOfBirth">The date of birth of the employee.</param>
        /// <param name="salary">The salary of the employee.</param>
        public Employee(int id, string name, DateTime dateOfBirth, double salary)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Salary = salary;
        }

        /// <summary>
        /// Builds an employee object from user input through the console.
        /// </summary>
        public void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please Enter the Name : ");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please Enter the Date of birth: ");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Please Enter the Basic Salary: ");
            Salary = Convert.ToDouble(Console.ReadLine());
        }

        /// <summary>
        /// Prints details of the employee to the console.
        /// </summary>
        public void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of birth : " + DateOfBirth);
            Console.WriteLine("Employee Age : " + Age);
            Console.WriteLine("Employee Salary : Rs." + Salary);
        }
    }
}
