namespace PracticingConcepts
{
    // Program to implement the concept of method overloading
    // i.e. functions having same name but different number and type of parameters...
    internal class Program
    {
        // Method to add two integers
        public int Add(int a, int b)
        {
            return a + b;
        }

        // Method to add three integers
        public int Add(int a, int b, int c)
        {
            return a + b + c;
        }

        // Method to add two doubles
        public double Add(double a, double b)
        {
            return a + b;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("  $$  Implementing the Concept of Function Overloading! $$ \n");
            Program p = new Program();

            // Call the overloaded methods
            int sum1 = p.Add(2, 3);
            int sum2 = p.Add(2, 3, 4);
            double sum3 = p.Add(2.5, 3.5);

            Console.WriteLine("Sum of 2 and 3: " + sum1);
            Console.WriteLine("Sum of 2, 3, and 4: " + sum2);
            Console.WriteLine("Sum of 2.5 and 3.5: " + sum3);
        }
    }
}
