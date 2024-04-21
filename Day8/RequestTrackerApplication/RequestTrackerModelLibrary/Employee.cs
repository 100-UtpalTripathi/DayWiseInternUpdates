using RequestTrackerModelLibrary;

namespace RequestTrackerModelLibrary
{
    public class Employee
    {
        public Department dept { get; set; }
        int age;
        DateTime dob;
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age
        {
            get
            {
                return age;
            }
        }
        public DateTime DateOfBirth
        {
            get => dob;
            set
            {
                dob = value;
                age = ((DateTime.Today - dob).Days) / 365;
            }
        }
        public double Salary { get; set; }
        public string Type { get; set; }
        public string Role { get; set; }

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
            Type = string.Empty;
            Role = "Employee";
        }
        public Employee(int id, string name, DateTime dateOfBirth, string role)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
            Role = role;
        }

        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please enter the Name");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please enter the Date of birth (yyyy-MM-dd)");
            while (!DateTime.TryParse(Console.ReadLine(), out dob))
            {
                Console.WriteLine("Invalid date format. Please enter the Date of birth (yyyy-MM-dd)");
            }
            Role = "Employee";
        }


        public override string ToString()
        {
            return "Employee Type : " + Type
                + "\nEmployee Id : " + Id
                + "\nEmployee Name " + Name
                + "\nDate of birth : " + DateOfBirth
                + "\nEmployee Age : " + Age
                + "\nEmployee Role " + Role;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || !(obj is Employee))
            {
                return false;
            }
            Employee e2 = (Employee)obj;
            return Id.Equals(e2.Id);
        }

        public static bool operator == (Employee a, Employee b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);

        }
        public static bool operator != (Employee a, Employee b)
        {
            return a.Id != b.Id;
        }
    }
}
