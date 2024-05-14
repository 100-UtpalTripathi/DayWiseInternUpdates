namespace ClinicAPI.Exceptions
{
    public class NoSuchDoctorException : Exception
    {
        string message;
        public NoSuchDoctorException()
        {
            message = "No Doctor found!";
        }
        public NoSuchDoctorException(string name)
        {
            message = name;
        }
        public override string Message => message;

    }
}
