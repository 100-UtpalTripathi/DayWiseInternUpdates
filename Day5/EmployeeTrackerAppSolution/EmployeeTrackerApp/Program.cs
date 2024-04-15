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
        void UnderstandingSwitchCase()
        {
            Console.Write("Please enter a number for day: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                case 4:
                    Console.WriteLine("Thursday");
                    break;
                case 5:
                    Console.WriteLine("Friday");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Weekend !!");
                    break;
                default:
                    Console.WriteLine("You dont know the number of days in a week???");
                    break;
                 
            }
        }
        void UnderstandingIterationWithFor()
        {
            for (int i = 0; i < 5; i = i + 2)
            {
                Console.WriteLine("Hello " + i);

            }
        }
        void UnderstandingIterationWithWhile()
        {
            int count = 10;
            while (count > 0)
            {
                count--;
                if (count == 7)
                    continue;
                Console.WriteLine("The value of count is: " + count);
                if (count == 4)
                    break;

            }
        }
        void UnderstandingIterationWithDoWhile()
        {
            int count = -1;
            do
            {
                Console.WriteLine("In Do while the value is:  " + count);
                Console.WriteLine("Please Enter the number: ");
                count = Convert.ToInt32(Console.ReadLine());
            } while (count > 0);
        }
        void UnderstandingArrays()
        {
            int[] numbers = { 444, 345, 666, 443, 455, 777 };
            int k = 3;
            int ThreeDigitNumbersHavingSameDigit = 0;
            for(int i = 0; i < numbers.Length; i++)
            {
                string temp = numbers[i].ToString();
                if(temp.Length == k && temp[0] == temp[1] && temp[1] == temp[2])
                    ThreeDigitNumbersHavingSameDigit++;

            }
            Console.WriteLine("The count of numbers: " + ThreeDigitNumbersHavingSameDigit);
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.UnderstandingSequenceStatments();
            //program.UnderstandingSelectionWithIf();
            //program.UnderstandingSwitchCase();
            //program.UnderstandingIterationWithWhile();
            //program.UnderstandingIterationWithDoWhile();
            program.UnderstandingArrays();

        }

        
    }
}
