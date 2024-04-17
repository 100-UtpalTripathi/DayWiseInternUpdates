namespace AppointmentManagementModelLibrary
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }

        public Doctor(int id, string name, string specialization, string contactNumber, string email)
        {
            Id = id;
            Name = name;
            Specialization = specialization;
            ContactNumber = contactNumber;
            Email = email;
        }
    }

}
