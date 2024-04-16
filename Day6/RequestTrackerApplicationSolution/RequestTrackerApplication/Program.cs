using RequestTrackerModelLibrary;
using System.Transactions;
using System.Xml.Linq;

namespace RequestTrackerApplication
{
    /// <summary>
    /// Represents the main program class.
    /// </summary>
    internal class Program
    {
        Employee[] employees;

        /// <summary>
        /// Initializes a new instance of the <see cref="Program"/> class.
        /// </summary>
        public Program()
        {
            employees = new Employee[3];
        }

        /// <summary>
        /// Prints the main menu options.
        /// </summary>
        void PrintMenu()
        {
            Console.WriteLine("1. Add Employee");
            Console.WriteLine("2. Print Employees");
            Console.WriteLine("3. Search Employee by ID");
            Console.WriteLine("4. Search and Update Employee Name by ID");
            Console.WriteLine("5. Search and Delete Employee by ID");
            Console.WriteLine("0. Exit");
        }

        /// <summary>
        /// Handles the interaction with the user for employee management.
        /// </summary>
        void EmployeeInteraction()
        {
            int choice = 0;
            do
            {
                PrintMenu();
                Console.WriteLine("Please select an option to continue: ");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye.....!");
                        break;
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        PrintAllEmployees();
                        break;
                    case 3:
                        SearchAndPrintEmployee();
                        break;
                    case 4:
                        SearchAndUpdateNameOfEmployeeById();
                        break;
                    case 5:
                        SearchAndDeleteEmployeeById();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again");
                        break;
                }
            } while (choice != 0);
        }

        /// <summary>
        /// Adds a new employee to the system.
        /// </summary>
        void AddEmployee()
        {
            if (employees[employees.Length - 1] != null)
            {
                Console.WriteLine("Sorry we have reached the maximum number of employees.");
                return;
            }
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] == null)
                {
                    employees[i] = CreateEmployee(i);
                }
            }

        }

        /// <summary>
        /// Prints details of all employees.
        /// </summary>
        void PrintAllEmployees()
        {
            bool flag = false;
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i] != null)
                {
                    flag = true;
                    PrintEmployee(employees[i]);
                };
            }
            if (flag == false)
            {
                Console.WriteLine("No Employees Available!");
            }
        }

        /// <summary>
        /// Creates a new employee object.
        /// </summary>
        /// <param name="id">The ID of the employee.</param>
        /// <returns>The created <see cref="Employee"/> object.</returns>
        Employee CreateEmployee(int id)
        {
            Employee employee = new Employee();
            employee.Id = 101 + id;
            employee.BuildEmployeeFromConsole();
            return employee;
        }

        /// <summary>
        /// Prints details of a single employee.
        /// </summary>
        /// <param name="employee">The employee to print.</param>
        void PrintEmployee(Employee employee)
        {
            Console.WriteLine("---------------------------");
            employee.PrintEmployeeDetails();
            Console.WriteLine("---------------------------");
        }

        /// <summary>
        /// Prompts the user to enter an employee ID and searches for the corresponding employee.
        /// </summary>
        void SearchAndPrintEmployee()
        {
            Console.WriteLine("Print One employee");
            int id = GetIdFromConsole();
            Employee? employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("Sorry, Employee ID is invalid!");
                return;
            }
            PrintEmployee(employee);
        }

        /// <summary>
        /// Prompts the user to enter an employee ID and updates the name of the corresponding employee.
        /// </summary>
        void SearchAndUpdateNameOfEmployeeById()
        {
            Console.WriteLine("\nEnter the Employee ID to Update Name details: ");
            int id = GetIdFromConsole();

            Employee? employee = SearchEmployeeById(id);
            if (employee == null)
            {
                Console.WriteLine("Sorry, Employee ID is invalid!");
                return;
            }
            Console.WriteLine("\nThese are the details of Employee having ID - " + id + " :");
            PrintEmployee(employee);
            Console.WriteLine("Enter the New Name: ");
            string? name;
            name = Console.ReadLine() ?? String.Empty;

            employee.Name = name;

            Console.WriteLine("\nEmployee details after updating the name!\n");
            PrintEmployee(employee);

            // Updating the changes in the database
            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i]?.Id == id)
                {
                    employees[i] = employee;
                    break;
                }
            }
        }

        /// <summary>
        /// Prompts the user to enter an employee ID and deletes the corresponding employee.
        /// </summary>
        void SearchAndDeleteEmployeeById()
        {
            Console.WriteLine("\nEnter the Employee ID to delete: ");
            int id = GetIdFromConsole();

            for (int i = 0; i < employees.Length; i++)
            {
                if (employees[i]?.Id == id)
                {
                    Console.WriteLine("Employee with ID " + id + " found and deleted!");
                    employees[i] = null; // Marking the Employee as deleted by assignig NULL
                    return;
                }
            }
            Console.WriteLine("Sorry, Employee ID is invalid!");
        }

        /// <summary>
        /// Searches for an employee by ID.
        /// </summary>
        /// <param name="id">The ID of the employee to search for.</param>
        /// <returns>The found <see cref="Employee"/> object, or null if not found.</returns>
        Employee? SearchEmployeeById(int id)
        {
            Employee? employee = null;
            for (int i = 0; i < employees.Length; i++)
            {

                if (employees[i] != null && employees[i].Id == id)
                {
                    employee = employees[i];
                    break;
                }
            }
            return employee;
        }

        /// <summary>
        /// Prompts the user to enter an employee ID and returns the parsed ID.
        /// </summary>
        /// <returns>The parsed employee ID.</returns>
        int GetIdFromConsole()
        {
            int id = 0;
            Console.Write("Please Enter the employee Id: ");
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid entry. Please try again");
            }
            return id;
        }

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.EmployeeInteraction();

            ContractEmployee employee = new ContractEmployee(101, "Ramu", DateTime.Now, 123213, 1233);
            employee.PrintEmployeeDetails();
        }
    }
}
