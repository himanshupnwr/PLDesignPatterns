using ChainOfResponsibility.V2.CustomExceptions;
using ChainOfResponsibility.V2.Handler;
using ChainOfResponsibility.V2.Model;

namespace ChainOfResponsibility.V2
{
    public class UserProcessor
    {
        public bool Register(User user)
        {
            try
            {
                var handler = new SocialSecurityNumberValidationHandler();

                handler.SetNext(new AgeValidationHandler()).SetNext(new NameValidationHandler()).SetNext(new CitizenshipRegionValidationHandler());

                handler.Handle(user);
            }
            catch (UserValidationException ex)
            {
                return false;
            }
            return true;
        }
    }
}
