/// <summary>
/// Represents a Doctor entity with basic information such as ID, name, age, experience, qualification, and speciality.
/// </summary>
internal class Doctor
{
    /// <summary>
    /// Gets the ID of the doctor.
    /// </summary>
    public int Id { get; private set; }

    /// <summary>
    /// Gets the name of the doctor.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Gets the age of the doctor.
    /// </summary>
    public int Age { get; private set; }

    /// <summary>
    /// Gets the years of experience of the doctor.
    /// </summary>
    public int Exp { get; private set; }

    /// <summary>
    /// Gets the qualification of the doctor.
    /// </summary>
    public string Qualification { get; private set; }

    /// <summary>
    /// Gets the speciality of the doctor.
    /// </summary>
    public string Speciality { get; private set; }

    /// <summary>
    /// Default constructor for Doctor class.
    /// </summary>
    public Doctor()
    {
        Id = 0;
        Name = string.Empty;
        Age = 0;
        Exp = 0;
        Qualification = string.Empty;
        Speciality = string.Empty;
    }

    /// <summary>
    /// Parameterized constructor for Doctor class.
    /// </summary>
    /// <param name="id">ID of the doctor.</param>
    /// <param name="name">Name of the doctor.</param>
    /// <param name="age">Age of the doctor.</param>
    /// <param name="exp">Years of experience of the doctor.</param>
    /// <param name="qualification">Qualification of the doctor.</param>
    /// <param name="speciality">Speciality of the doctor.</param>
    public Doctor(int id, string name, int age, int exp, string qualification, string speciality)
    {
        Id = id;
        Name = name;
        Age = age;
        Exp = exp;
        Qualification = qualification;
        Speciality = speciality;
    }

    /// <summary>
    /// Prints the details of the doctor to the console.
    /// </summary>
    public void PrintDoctorDetails()
    {
        Console.WriteLine($"Id: {Id}\nName: {Name}\nAge: {Age}\n" +
            $"Exp: {Exp}\nQualification: {Qualification}\n" +
            $"Speciality: {Speciality}\n");
    }
}
