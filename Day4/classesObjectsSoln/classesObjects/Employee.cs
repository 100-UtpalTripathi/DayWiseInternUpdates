using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace classesObjects
{
    class Employee
    {
        double salary;
        public int Id { get; private set; }

        public string Name { get; set; }

        public double Salary
        {
            set
            {
                salary = value;
            }
            get
            {
                return (salary - (salary * 10 / 100));
            }
        }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        /// <summary>
        /// Default constructor Added!
        /// </summary>
        public Employee()
        {
            Id = 0;
            Name = string.Empty;
            Email = string.Empty;
            DateOfBirth = DateTime.MinValue;
            Salary = 0;
        }

        /// <summary>
        /// Parameterized constructor Added!
        /// </summary>
        /// <param name="id"> ID of the Employee</param>
        public Employee(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Paramterized constructor calling another parametrized constructor, i.e. chaining
        /// </summary>
        /// <param name="id"> ID of the Employee</param>
        /// <param name="name"> Name of the Employee</param>
        /// <param name="salary"> Salary of the Employee</param>
        /// <param name="dateOfBirth">DOB</param>
        /// <param name="email">Email....</param>

        public Employee(int id, string name, double salary, DateTime dateOfBirth, string email) : this(id)
        {
            Name = name;
            Salary = salary;
            DateOfBirth = dateOfBirth;
            Email = email;
        }

        public void Work()
        {
            Console.WriteLine("Works");
        }
    }
}
