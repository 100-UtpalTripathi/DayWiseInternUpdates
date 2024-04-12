using System;
using System.Linq;
using System.Xml.Linq;

namespace Assignment
{
    /// <summary>
    /// A simple program to create and manage doctor records.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Takes a string input from the user.
        /// </summary>
        /// <param name="PrintValue">The prompt message to be displayed to the user.</param>
        /// <returns>The string input provided by the user.</returns>
        string TakingStringInput(string PrintValue)
        {
            string? str;
            do
            {
                str = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(str))
                    Console.Write($"Invalid input, Please Enter {PrintValue} again:\n");

            } while (string.IsNullOrWhiteSpace(str));
            return str;

        }

        /// <summary>
        /// Takes an integer input from the user.
        /// </summary>
        /// <param name="PrintValue">The prompt message to be displayed to the user.</param>
        /// <returns>The integer input provided by the user.</returns>
        int TakingIntInput(string PrintValue)
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write($"Invalid input! Please Enter {PrintValue} again:");
            }
            return value;
        }

        /// <summary>
        /// Creates a new Doctor instance by taking input from the console.
        /// </summary>
        /// <returns>A new Doctor instance created with user input.</returns>
        Doctor CreateDoctorThroughConsole()
        {
            int id;
            string name;
            int age;
            int exp;
            string qualification;
            string speciality;

            Console.Write("Id: ");
            id = TakingIntInput("Id");

            Console.Write("Name: ");
            name = TakingStringInput("Name");

            Console.Write("Age: ");
            age = TakingIntInput("Age");

            Console.Write("Experience: ");
            exp = TakingIntInput("Experience");

            Console.Write("Qualification: ");
            qualification = TakingStringInput("Qualification");

            Console.Write("Speciality: ");
            speciality = TakingStringInput("Speciality");

            Doctor TempDoctor = new Doctor(id, name, age, exp, qualification, speciality);
            return TempDoctor;
        }

        /// <summary>
        /// Prints details of doctors by speciality.
        /// </summary>
        /// <param name="doctors">Array of Doctor objects.</param>
        /// <param name="speciality">The speciality to search for.</param>
        public void PrintDoctorsBySpeciality(Doctor[] doctors, string speciality)
        {
            Console.WriteLine($"Doctors in {speciality}:");
            bool found = false;
            foreach (var doctor in doctors)
            {
                if (doctor.Speciality == speciality)
                {
                    Console.WriteLine($"Id: {doctor.Id}, Name: {doctor.Name}, Age: {doctor.Age}, Exp: {doctor.Exp}, Qualification: {doctor.Qualification}, Speciality: {doctor.Speciality}");
                    found = true;
                }
            }
            if (!found)
            {
                Console.WriteLine("No doctors found with the given speciality.");
            }
        }

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("   $$  Welcome to Hospital Application!   $$    \n");
            Program p = new Program();
            Console.Write("Enter the Number of Doctors:");
            int NumberOfDoctors = p.TakingIntInput("Number of Doctors");

            Doctor[] doctors = new Doctor[NumberOfDoctors];

            for (int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine($"\nEnter details for Doctor {i + 1}:");
                doctors[i] = p.CreateDoctorThroughConsole();

            }

            for (int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine($"\nDetails for Doctor {i + 1}:");
                doctors[i].PrintDoctorDetails();

            }

            Console.WriteLine("Enter the Speciality to search for Doctors: ");
            string speciality = p.TakingStringInput("Speciality");

            p.PrintDoctorsBySpeciality(doctors, speciality);
        }
    }
}
