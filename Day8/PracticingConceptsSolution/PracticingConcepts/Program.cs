namespace PracticingConcepts
{

    internal class Student
    {
        public int Id { get; set; }
        string[] skills = new string[3];
        public string Name { get; set; }
        public string this[int index]
        {
            get { return skills[index]; }
            set { skills[index] = value; }
        }
        public override string ToString()
        {
            string data = Id + " " + Name + " ";
            for (int i = 0; i < skills.Length; i++)
                data += skills[i] + " ";
            return data;
        }
    }
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
            //Console.WriteLine("  $$  Implementing the Concept of Function Overloading! $$ \n");
            //Program p = new Program();

            //// Call the overloaded methods
            //int sum1 = p.Add(2, 3);
            //int sum2 = p.Add(2, 3, 4);
            //double sum3 = p.Add(2.5, 3.5);

            //Console.WriteLine("Sum of 2 and 3: " + sum1);
            //Console.WriteLine("Sum of 2, 3, and 4: " + sum2);
            //Console.WriteLine("Sum of 2.5 and 3.5: " + sum3);

            Student student = new Student() { Name = "Ramu", Id = 101 };
            student[0] = "C";
            student[1] = "Java";
            student[2] = "C#";
            Console.WriteLine(student);
        }
    }
}
