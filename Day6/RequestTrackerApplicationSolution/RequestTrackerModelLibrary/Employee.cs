﻿namespace RequestTrackerModelLibrary
{
    public class Employee : IClientInteraction, IInternalCompanyWorking
    {
        public Department EmployeeDepartment { get; set; }
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

        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Salary = 0.0;
            DateOfBirth = new DateTime();
            Type = string.Empty;
        }
        public Employee(int id, string name, DateTime dateOfBirth)
        {
            Id = id;
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public virtual void BuildEmployeeFromConsole()
        {
            Console.WriteLine("Please Enter the Name: ");
            Name = Console.ReadLine() ?? String.Empty;
            Console.WriteLine("Please Enter the Date of birth: ");
            DateOfBirth = Convert.ToDateTime(Console.ReadLine());
        }

        public virtual void PrintEmployeeDetails()
        {
            Console.WriteLine("Employee Id : " + Id);
            Console.WriteLine("Employee Name " + Name);
            Console.WriteLine("Date of birth : " + DateOfBirth);
            Console.WriteLine("Employee Age : " + Age);
        }

        public void GetOrder()
        {
            Console.WriteLine("Order fetched by " + Name);
        }

        public void GetPayment()
        {
            Console.WriteLine("Get the payment as per terms");
        }

        public void RaiseRequest()
        {
            throw new NotImplementedException();
        }

        public void CloseRequest()
        {
            throw new NotImplementedException();
        }
    }
}