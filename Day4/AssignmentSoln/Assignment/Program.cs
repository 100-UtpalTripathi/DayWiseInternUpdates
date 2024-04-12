using System.Xml.Linq;

namespace Assignment
{
    
    internal class Program
    {
        string TakingStringInput()
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
        int TakingIntInput()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value) || value <= 0)
            {
                Console.Write("\nInvalid input! Please enter a valid integer:");
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
            id = TakingIntInput();

            Console.Write("Name: ");
            name = TakingStringInput();

            Console.Write("Age: ");
            age = TakingIntInput();

            Console.Write("Experience: ");
            exp = TakingIntInput();

            Console.Write("Qualification: ");
            qualification = TakingStringInput();

            Console.Write("Speciality: ");
            speciality = TakingStringInput();


            Doctor TempDoctor = new Doctor(id, name, age, exp, qualification, speciality);
            return TempDoctor;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.Write("Enter the Number of Doctors:");
            int NumberOfDoctors = p.TakingIntInput();

            Doctor[] doctors = new Doctor[NumberOfDoctors];
            
            for(int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine($"Enter details for Doctor {i + 1}:");
                doctors[i] = p.CreateDoctorThroughConsole();

            }

            for (int i = 0; i < doctors.Length; i++)
            {
                Console.WriteLine($"Details for Doctor {i + 1}:");
                doctors[i].PrintDoctorDetails();

            }
        }
    }
}
