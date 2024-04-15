using RequestTrackerModelLibrary;

namespace RequestTrackerApplication
{
    internal class Program
    {
        void CreateEmployee()
        {
            Employee employee = new Employee();
            employee.Id = 101;
            employee.BuildEmployeeFromConsole();
            Console.WriteLine("----------------------------");
            employee.PrintEmployeeDetails();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.CreateEmployee();
        }
    }
}