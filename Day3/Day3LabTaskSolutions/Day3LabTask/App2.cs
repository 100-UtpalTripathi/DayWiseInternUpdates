using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3LabTask
{
    internal class App2
    {
        public void myMethod()
        {
            int greatest = int.MinValue;
            string? num;
            int n;
            Console.WriteLine("Enter numbers (enter a negative number to stop):");
            
            do
            {
                Console.Write("Type a number, and then press Enter: ");
                num = Console.ReadLine();

                int cleanNum1;
                while (!int.TryParse(num, out cleanNum1))
                {
                    Console.Write("This is not valid input. Please enter a numeric value: ");
                    num = Console.ReadLine();
                }

                n = Convert.ToInt32(num);
                if (n >= 0 && n > greatest)
                {
                    greatest = n;
                }
            } while (n >= 0);

            Console.WriteLine("The greatest number entered is: " + greatest);
        }
    }
}
