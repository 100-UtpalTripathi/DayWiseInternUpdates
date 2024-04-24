using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingModelLibrary
{
    public class Customer : IEquatable<Customer>
    {
        public int Id { get; set; }
        public string Phone { get; set; } = String.Empty;
        public int Age { get; set; }


        public Customer()
        {
            
        }

        public Customer(int id, string phone, int age)
        {
            Id = id;
            Phone = phone;
            Age = age;
        }


        public override string ToString()
        {
            return "Id : " + Id +
                "\nPhone : " + Phone +
                "\nAge : " + Age;
        }

        public bool Equals(Customer? other)
        {
            return this.Id.Equals(other.Id);
        }

    }
}