namespace CleanDesign.Infrastructure.Exceptions
{
    public class EmailNotRegisteredException : Exception
    {
        public EmailNotRegisteredException() { }

        public EmailNotRegisteredException(string message) : base(message)
        {
        }

        public EmailNotRegisteredException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
