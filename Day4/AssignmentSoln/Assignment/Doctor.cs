using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    internal class Doctor
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Exp { get; private set; }
        public string Qualification { get; private set; }
        public string Speciality { get; private set; }

        public Doctor()
        {
            Id = 0;
            Name = string.Empty;
            Age = 0;
            Exp = 0;
            Qualification = string.Empty;
            Speciality = string.Empty;
        }
        public Doctor(int id, string name, int age, int exp, string qualification, string speciality)
        {
            Id = id;
            Name = name;
            Age = age;
            Exp = exp;
            Qualification = qualification;
            Speciality = speciality;
        }
        public void PrintDoctorDetails()
        {
            Console.WriteLine($"Id: {Id}\nName: {Name}\nAge: {Age}\n" +
                $"Exp: {Exp}\nQualification: {Qualification}\n" +
                $"Speciality: {Speciality}\n");
            
        }

    }
}
