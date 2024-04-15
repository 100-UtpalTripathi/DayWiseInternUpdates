namespace EmployeeTrackerApp
{
    internal class Program
    {
        void UnderstandingSequenceStatements()
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Hi");
            int num1, num2;
            num1 = 100;
            num2 = 20;
            int num3 = num1 / num2;
            Console.WriteLine($"The result of {num1} divided by {num2} is {num3}");
        }
        void UnderstandingSelectionWithIf()
        {
            string strName = "Albatross";
            if (strName == "Albatross")
            {
                Console.WriteLine("Welcome Albatross. you are authorized! ");
                Console.WriteLine("Bingo!!");
            }
            else if (strName == "Somu")
                Console.WriteLine("You are Somu not Albatross. ONly Basic access");
            else
                Console.WriteLine("I don't know who you are. Get out...");

        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.UnderstandingSequenceStatements();
            program.UnderstandingSelectionWithIf();

        }
    }
}
