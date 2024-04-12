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

                if (string.IsNullOrWhiteSpace(str))
                    Console.Write($"Invalid input, Please Enter {PrintValue} again:\n");

            } while (string.IsNullOrWhiteSpace(str));
            return str;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Card Validator Application!\n");
            Console.Write("Enter the Card Number:");
            string CardNumber = TakingStringInput("Card Number");
        }
    }
}
