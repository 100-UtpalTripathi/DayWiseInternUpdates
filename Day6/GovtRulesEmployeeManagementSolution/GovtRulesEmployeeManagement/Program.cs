using GovtRulesEmployeeManagementModelLibrary;
namespace GovtRulesEmployeeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Created instances of ABC and XYZ employees
            ABC abcEmployee = new ABC(1, "John", "IT", "Developer", 50000);
            XYZ xyzEmployee = new XYZ(2, "Jane", "HR", "Manager", 60000);

            // Created an interface reference variable of type IGovtRules
            IGovtRules govtRulesInterface;

            // Assign ABC instance to the interface reference variable
            govtRulesInterface = abcEmployee;

            // Use the interface reference variable to call interface methods
            Console.WriteLine("\nABC Company, Employee Details!\n");
            abcEmployee.PrintEmployeeDetails();
            Console.WriteLine();
            Console.WriteLine("Printing Extra Benefits using Interface Object !\n");
            Console.WriteLine("\nEmployee PF: " + govtRulesInterface.CalculateEmployeePF(abcEmployee.BasicSalary));
            Console.WriteLine("\n" + govtRulesInterface.GetLeaveDetails());
            Console.WriteLine("\nGratuity Amount: " + govtRulesInterface.CalculateGratuityAmount(10, abcEmployee.BasicSalary));

            Console.WriteLine();

            // Assign XYZ instance to the interface reference variable
            govtRulesInterface = xyzEmployee;
            Console.WriteLine("\nXYZ Company :  Employee Details! \n");
            xyzEmployee.PrintEmployeeDetails();
            Console.WriteLine();
            Console.WriteLine("Printing Extra Benefits using Interface Object !\n");
            // Use the same interface reference variable to call interface methods for XYZ
            Console.WriteLine("\nXYZ Employee Details:");
            Console.WriteLine("\nEmployee PF: " + govtRulesInterface.CalculateEmployeePF(xyzEmployee.BasicSalary));
            Console.WriteLine("\n" + govtRulesInterface.GetLeaveDetails());
            Console.WriteLine("\nGratuity Amount: " + govtRulesInterface.CalculateGratuityAmount(5, xyzEmployee.BasicSalary));

        
        }
    }
}
