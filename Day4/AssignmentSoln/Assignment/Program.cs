using System.Xml.Linq;

namespace Assignment
{
    
    internal class Program
    {
        string TakingStringInput(string PrintValue)
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
        int TakingIntInput(string PrintValue)
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write($"Invalid input! Please Enter {PrintValue} again:");
            }
            return value;

        }
        Doctor CreateDoctorThroughConsole()
        {
            int id;
            string name;
            int age;
            int exp;
            string qualification;
            string speciality;

            Console.Write("Id: ");
            id = TakingIntInput("Id");

            Console.Write("Name: ");
            name = TakingStringInput("Name");

            Console.Write("Age: ");
            age = TakingIntInput("Age");

            Console.Write("Experience: ");
            exp = TakingIntInput("Experience");

            Console.Write("Qualification: ");
            qualification = TakingStringInput("Qualification");

            Console.Write("Speciality: ");
            speciality = TakingStringInput("Speciality");


            Doctor TempDoctor = new Doctor(id, name, age, exp, qualification, speciality);
            return TempDoctor;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.Write("Enter the Number of Doctors:");
            int NumberOfDoctors = p.TakingIntInput("Number of Doctors");

            Doctor[] doctors = new Doctor[NumberOfDoctors];
            
            for(int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine($"\nEnter details for Doctor {i + 1}:");
                doctors[i] = p.CreateDoctorThroughConsole();

            }

            for (int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine($"\nDetails for Doctor {i + 1}:");
                doctors[i].PrintDoctorDetails();

            }
        }
    }
}
