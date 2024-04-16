using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerModelLibrary
{
    public class ContractEmployee : Employee
    {
        public double WagesPerDay { get; set; }
        public ContractEmployee()
        {
            WagesPerDay = 0;
            Console.WriteLine("Contract employee constructor");
        }
        public ContractEmployee(int id, string name, DateTime dateOfBirth, double salary, double wagesPerDay) : base(id, name, dateOfBirth, salary)
        {
            Console.WriteLine("Contract Employee class prameterized constructor");

            WagesPerDay = wagesPerDay;
        }
    }
}