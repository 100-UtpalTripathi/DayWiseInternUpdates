namespace ClinicAPI.Exceptions
{
    public class NoDoctorsFoundException : Exception
    {
        string message;
        public NoDoctorsFoundException()
        {
            message = "No Doctors found!";
        }
        public NoDoctorsFoundException(string name)
        {
            message = name;
        }
        public override string Message => message;
    }
}
