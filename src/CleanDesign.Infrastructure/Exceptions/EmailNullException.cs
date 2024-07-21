namespace CleanDesign.Infrastructure.Exceptions
{
    public class EmailNullException : ArgumentNullException
    {
        public EmailNullException() { }
        public EmailNullException(string message) : base(message) { }
        public EmailNullException(string message, Exception inner) : base(message, inner) { }
    }
}
