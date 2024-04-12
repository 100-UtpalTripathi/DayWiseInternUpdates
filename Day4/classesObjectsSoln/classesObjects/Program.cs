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

            Employee employee3 = new Employee(103, "Bimu", 123423, new DateTime(2000, 05, 07), "bimu@abcorp.com");
            Console.WriteLine(employee3.Id + " " + employee3.Name);
            employee.Work();
        }
    }
}
