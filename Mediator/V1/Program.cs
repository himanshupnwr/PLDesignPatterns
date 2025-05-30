using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Mediator";
            TeamChatRoom room = new();

            var sven = new Lawyer("sven");
            var kenneth = new Lawyer("Kenneth");
            var ann = new AccountManager("Ann");
            var john = new AccountManager("John");
            var kylie = new AccountManager("Kyle");

            room.Regsiter(sven);
            room.Regsiter(kenneth);
            room.Regsiter(ann);
            room.Regsiter(john);
            room.Regsiter(kylie);

            ann.Send("Hi everyone, can someone have a look at file ABC123? I need a compliance check");
            sven.Send("On It!");

            //To specific user
            sven.Send("Ann", "Could you join me in a teams call?");
        }
    }
}
