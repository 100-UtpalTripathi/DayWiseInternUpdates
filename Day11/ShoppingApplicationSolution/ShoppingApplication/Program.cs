namespace ShoppingApplication
{
    internal class Program
    {
        void Calculate(Func<int, int, int> cal)
        {
            int n1 = 10, n2 = 20;
            int result = cal(n1, n2);
            Console.WriteLine($"The sum of {n1} and {n2} is {result}");
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Program program = new Program();
            
            Func<int, int, int> c1 = (num1, num2) => (num1 + num2);
            program.Calculate(c1);

        }
    }
}
