using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3LabTask
{
    internal class App4
    {
        public void myMethod()
        {
            string? name;

            Console.WriteLine("Enter your name:");
            do
            {
                Console.Write("\nName: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    Console.WriteLine("Invalid input. Please enter a valid name.");

            } while (string.IsNullOrWhiteSpace(name));

            int length = name.Length;
            Console.WriteLine("Length of your name is: " + length);
        }
    }
}
