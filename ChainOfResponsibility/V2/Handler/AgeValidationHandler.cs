using ChainOfResponsibility.V2.CustomExceptions;
using ChainOfResponsibility.V2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility.V2.Handler
{
    public class AgeValidationHandler : Handler<User>
    {
        public override void Handle(User user)
        {
            if(user.Age < 18)
            {
                throw new UserValidationException("You have to be 18 years or older");
            }
            base.Handle(user);
        }
    }
}
