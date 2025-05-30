using ChainOfResponsibility.V2.CustomExceptions;
using ChainOfResponsibility.V2.Model;
using ChainOfResponsibility.V2.Validator;

namespace ChainOfResponsibility.V2.Handler
{
    public class SocialSecurityNumberValidationHandler : Handler<User>
    {
        private SocialSecurityNumberValidator socialSecurityNumberValidator
            = new SocialSecurityNumberValidator();

        public override void Handle(User request)
        {
            if(!socialSecurityNumberValidator.Validate(request.SocialSecurityNumber, request.CitizenshipRegion))
            {
                throw new UserValidationException("Social security number could not be validated");
            }
            base.Handle(request);
        }

    }
}
