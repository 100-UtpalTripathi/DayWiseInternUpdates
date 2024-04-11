using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;

namespace Day3LabTask
{
    internal class App3
    {
        public void myMethod()
        {
            string? num;
            int n;
            Console.WriteLine("Enter numbers (enter a negative number to stop):");
            int sum = 0;
            int count = 0;
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
                if (n % 7 == 0)
                {
                    sum += n;
                    count++;
                }
            } while (n >= 0);

            if(count == 0)
            {
                Console.WriteLine("No numbers divisible by 7 found!\n ");
            }
            else
            {
                Console.WriteLine("The average of numbers divisible by 7: " + sum / count);
            }
            
        }
    }
}
