using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3LabTask
{
    internal class App5
    {
        static string takeInput(string printVal)
        {
            string? temp;
            do
            {
                temp = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(temp))
                    Console.Write($"\nInvalid Credentials. Enter {printVal} again: ");

            } while (string.IsNullOrWhiteSpace(temp));

            return temp;
        }
        public void myMethod()
        {
            const string validUsername = "ABC";
            const string validPassword = "123";
            int attempts = 0;

            while (attempts < 3)
            {
                Console.Write("Enter username: ");
                string username = takeInput("username");

                Console.Write("Enter password: ");
                string password = takeInput("password");

                if (username == validUsername && password == validPassword)
                {
                    Console.WriteLine("Login successful!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid credentials! Please try again.");
                    attempts++;
                }
            }

            if (attempts == 3)
            {
                Console.WriteLine("You have exceeded the maximum number of attempts. Access denied.");
            }
        }
    }
}
