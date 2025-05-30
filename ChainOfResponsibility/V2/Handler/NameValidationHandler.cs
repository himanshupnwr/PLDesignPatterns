using ChainOfResponsibility.V2.CustomExceptions;
using ChainOfResponsibility.V2.Model;

namespace ChainOfResponsibility.V2.Handler
{
    public class NameValidationHandler : Handler<User>
    {
        public override void Handle(User user)
        {
            if (user.Name.Length <= 1)
            {
                throw new UserValidationException("Your name is unlikely this short.");
            }

            base.Handle(user);
        }
    }
}
