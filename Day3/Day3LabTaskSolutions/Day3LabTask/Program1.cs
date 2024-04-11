namespace Day3LabTask
{
    internal class Program1
    {
        static double Add(double num1, double num2)
        {
            return num1 + num2;
        }
        static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }
        static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }
        static double Divide(double num1, double num2)
        {
            return num1 / num2;
        }
        static double Remainder(double num1, double num2)
        {
            return num1 % num2;
        }
        static void Main(string[] args)
        {
            string? num1;
            string? num2;

            // Asking the user to type the first number.
            Console.Write("Type a number, and then press Enter: ");
            num1 = Console.ReadLine();

            double cleanNum1;
            while (!double.TryParse(num1, out cleanNum1))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                num1 = Console.ReadLine();
            }

            // Ask the user to type the second number.
            Console.Write("Type another number, and then press Enter: ");
            num2 = Console.ReadLine();

            double cleanNum2;
            while (!double.TryParse(num2, out cleanNum2))
            {
                Console.Write("This is not valid input. Please enter a numeric value: ");
                num2 = Console.ReadLine();
            }

            double n1 = Convert.ToDouble(num1);
            double n2 = Convert.ToDouble(num2);

            double sum = Add(n1, n2);
            double subtraction = Subtract(n1, n2);
            double division = Divide(n1, n2);
            double product = Multiply(n1, n2);
            double remainder = Remainder(n1, n2);

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Division: {division}");
            Console.WriteLine($"Subtraction: {subtraction}");
            Console.WriteLine($"Remainder: {remainder}");
        }
    }
}
