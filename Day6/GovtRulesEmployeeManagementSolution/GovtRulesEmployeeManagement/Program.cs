using GovtRulesEmployeeManagementModelLibrary;
namespace GovtRulesEmployeeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ABC abcEmployee = new ABC(1, "John", "IT", "Developer", 50000);
            
            Console.WriteLine("\nABC Employee Details:");
            abcEmployee.PrintEmployeeDetails(); // Print employee details

            Console.WriteLine();

            // Create an XYZ employee
            XYZ xyzEmployee = new XYZ(2, "Jane", "HR", "Manager", 60000);
            // xyzEmployee.BuildEmployeeFromConsole(); // Input employee details

            Console.WriteLine("\nXYZ Employee Details:");
            xyzEmployee.PrintEmployeeDetails(); // Print employee detail
        }
    }
}
