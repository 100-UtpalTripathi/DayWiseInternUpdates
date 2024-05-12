using RequestTrackerBLLibrary;
using RequestTrackerModelLibrary;
using System.Threading.Channels;

namespace RequestTrackerFEAPP
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            { 
                Console.WriteLine("  $$    Welcome to Request Tracker Application!   $$   ");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                // Switch statement to handle user's choice
                switch (choice)
                {
                    case "1":
                        await Login();
                        break;
                    case "2":
                        Register();
                        break;
                    case "3":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Please Choose Correct Option!");
                        break;
                }
            }
        }

        static async Task Login()
        {
            Console.Write("Enter your ID: ");
            int id;
            if (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
                return;
            }

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();

            // Instantiate the repository and business logic
            using (var context = new RequestTrackerContext())
            {
                var repository = new EmployeeRepository(context);
                var employeeLoginBL = new EmployeeLoginBL(repository);

                // Call the business logic layer to authenticate the user
                var employee = new Employee { Id = id, Password = password };
                bool isAuthenticated = await employeeLoginBL.Login(employee);

                if (isAuthenticated)
                {
                    Console.WriteLine("Login successful!");

                    // Proceed to the appropriate menu based on user role (UserMenu or AdminMenu)
                    // For now, let's just print a message indicating successful login
                }
                else
                {
                    Console.WriteLine("Login failed. Invalid ID or password.");
                }
            }
        }

        static void Register()
        {
            // Implement registration logic
            // Prompt the user to enter necessary details and call the appropriate business logic method
        }
    }
}