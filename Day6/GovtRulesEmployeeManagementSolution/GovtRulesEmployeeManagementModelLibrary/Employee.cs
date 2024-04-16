namespace GovtRulesEmployeeManagementModelLibrary
{
    public class Employee
    {
        public int EmpId { get; }
        public string Name { get; }
        public string Department { get; }
        public string Designation { get; }
        public double BasicSalary { get; }

        public Employee(int empId, string name, string department, string designation, double basicSalary)
        {
            EmpId = empId;
            Name = name;
            Department = department;
            Designation = designation;
            BasicSalary = basicSalary;
        }
    }
}
