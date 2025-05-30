namespace ChainOfResponsibility.V2.CustomExceptions
{
    public class UnsupportedSocialSecurityNumberException : Exception
    {
        public UnsupportedSocialSecurityNumberException(string message) : base(message) { }
    }
}
