namespace Day3LabTask
{
    internal class App1
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

        static void RunBasicArithmeticOperations()
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
            while (!double.TryParse(num2, out cleanNum2) || cleanNum2 == 0)
            {
                Console.Write("This is not valid input. Please enter a non-zero numeric value: ");
                num2 = Console.ReadLine();
            }

            double n1 = Convert.ToDouble(num1);
            double n2 = Convert.ToDouble(num2);

            double sum = Add(n1, n2);
            double subtraction = Subtract(n1, n2);
            double product = Multiply(n1, n2);

            double division = Divide(n1, n2);
            double remainder = Remainder(n1, n2);

            Console.WriteLine($"Sum: {sum}");
            Console.WriteLine($"Product: {product}");
            Console.WriteLine($"Division: {division}");
            Console.WriteLine($"Subtraction: {subtraction}");
            Console.WriteLine($"Remainder: {remainder}");
        }
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n\n Choose an application to run: \n");
                Console.WriteLine("1. Basic Arithmetic Operations");
                Console.WriteLine("2. Program 2");
                Console.WriteLine("3. Program 3");
                Console.WriteLine("4. Program 4");
                Console.WriteLine("5. Program 5");
                Console.WriteLine("6. Program 6");
                Console.WriteLine("7. Exit \n");


                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            RunBasicArithmeticOperations();
                            break;
                        case 2:
                            App2 p2 = new App2();
                            p2.myMethod();
                            break;
                        case 3:
                            App3 p3 = new App3();
                            p3.myMethod();
                            break;
                        case 4:
                            App4 p4 = new App4();
                            p4.myMethod();
                            break;
                        case 5:
                            App5 p5 = new App5();
                            p5.myMethod();
                            break;
                        case 6:
                            App6 p6 = new App6();
                            p6.myMethod();
                            break;
                        case 7:
                            exit = true;
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please choose a number from 1 to 7.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

        }
        
    }
}
