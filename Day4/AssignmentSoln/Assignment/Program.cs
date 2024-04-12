using System.Xml.Linq;

namespace Assignment
{
    
    internal class Program
    {
        string takingStringInput()
        {
            string? str;
            do
            {
                str = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(str))
                    Console.Write("\nInvalid input, Please Enter again:\n");

            } while (string.IsNullOrWhiteSpace(str));
            return str;

        }
        int takingIntInput()
        {
            int? id;

        }
        Doctor createDoctors()
        {
            int id;
            string? name;
            Console.Write("Id: ");

            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Invalid input! Please enter a valid integer for Id:");
            }


            do
            {
                Console.Write("\nName: ");
                name = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                    Console.WriteLine("Invalid input. Please enter a valid name!\n");

            } while (string.IsNullOrWhiteSpace(name));

            int age;
            do
            {
                Console.Write("Age: ");
            } while (!int.TryParse(Console.ReadLine(), out age) || age <= 0);

            int exp;
            do
            {
                Console.Write("Experience (in years): ");
            } while (!int.TryParse(Console.ReadLine(), out exp) || exp < 0);



            Doctor d = new Doctor(id, name, age, exp, qualification, speciality);
            return d;
        }
        static void Main(string[] args)
        {
            Doctor[] doctors = new Doctor[3];
            
            for(int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine($"Enter details for Doctor {i + 1}:");

            }
        }
    }
}
