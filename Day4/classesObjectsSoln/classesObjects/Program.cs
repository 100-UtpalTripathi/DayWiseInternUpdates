namespace classesObjects
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            employee.Name = "Ramu";
            employee.Salary = 10000;
            employee.DateOfBirth = new DateTime(2000, 12, 18);
            employee.Email = "ramu@abccorp.com";
            Employee employee2 = new Employee
            {
                Name = "Somu",
                DateOfBirth = new DateTime(2000, 3, 6),
                Email = "somu@abccorp.com",
                Salary = 40000
            };

            Console.WriteLine(employee2.Salary);
            employee.Work();
        }
    }
}
