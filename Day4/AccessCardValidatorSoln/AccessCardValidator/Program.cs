using System;
using System.Linq;

namespace AccessCardValidator
{
    internal class Program
    {
        static string TakingStringInput(string PrintValue)
        {
            string? str;
            do
            {
                str = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(str) || str.Length != 16)
                {
                    Console.Write($"Invalid input! {PrintValue} must be exactly 16 digits long. Please enter again:");
                    continue;
                }

                if (!str.All(char.IsDigit))
                {
                    Console.Write($"Invalid input! {PrintValue} must contain only digits. Please enter again:");
                    continue;
                }

            } while (string.IsNullOrWhiteSpace(str) || str.Length != 16 || !str.All(char.IsDigit));

            return str;
        }

        static string ReverseCardNumber(string CardNumber)
        {
            return new string(CardNumber.Reverse().ToArray());
        }

        static bool CheckValidation(string CardNumber)
        {
            // Ensure the card number is not all zeros
            if (CardNumber.All(c => c == '0'))
            {
                return false;
            }

            string NewCardNumber = ReverseCardNumber(CardNumber);
            int result = CalculateChecksum(NewCardNumber);
            return result % 10 == 0;
        }

        static int CalculateChecksum(string input)
        {
            int sum = 0;
            for (int i = 0; i < input.Length; i++)
            {
                int digit = (int)Char.GetNumericValue(input[i]);
                if (i % 2 != 0) // Even position
                {
                    digit *= 2;
                    if (digit > 9) // Check if the result is two digits
                    {
                        sum += SumOfDigits(digit.ToString());
                    }
                    else
                    {
                        sum += digit;
                    }
                }
                else // Odd position
                {
                    sum += digit;
                }
            }
            return sum;
        }

        static int SumOfDigits(string input)
        {
            int sum = 0;
            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    sum += (int)Char.GetNumericValue(c);
                }
            }
            return sum;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("$$     Welcome to Card Validator Application!   $$\n\n");
            Console.Write("Enter the Numeric Card Number:");
            string CardNumber = TakingStringInput("Card Number");

            bool IsValid = CheckValidation(CardNumber);
            if (IsValid)
            {
                Console.WriteLine("Success, User Authenticated!");
            }
            else
            {
                Console.WriteLine("User Authentication Failed, Invalid User!");
            }
        }
    }
}
