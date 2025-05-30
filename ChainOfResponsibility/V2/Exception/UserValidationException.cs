
namespace ChainOfResponsibility.V2.CustomExceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string message) : base(message) { }
    }
}
