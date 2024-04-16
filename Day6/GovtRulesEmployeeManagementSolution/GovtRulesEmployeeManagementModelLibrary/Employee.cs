namespace GovtRulesEmployeeManagementModelLibrary
{
    public class Employee
    {
        public int EmpId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public double BasicSalary { get; set; }
        public string EmployerName { get; set; } = string.Empty;

        public Employee()
        {
            EmpId = 0;
            Name = string.Empty;
            Department = string.Empty;
            Designation = string.Empty; 
            BasicSalary = 0;
        }
        public Employee(int empId, string name, string department, string designation, double basicSalary)
        {
            EmpId = empId;
            Name = name;
            Department = department;
            Designation = designation;
            BasicSalary = basicSalary;
        }

        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please Enter the Employee Id: ");
            EmpId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the Name: ");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please Enter the Department: ");
            Department = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please Enter the Designation: ");
            Designation = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please Enter the Basic Salary: ");
            BasicSalary = Convert.ToDouble(Console.ReadLine());
        }

        // Function to print employee details
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
