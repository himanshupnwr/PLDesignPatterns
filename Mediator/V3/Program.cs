using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator.V3
{
    public class Program
    {
        static void Main(string[] args) {
            var teamchat = new TeamChatRoom();

            var steve = new Developer("Steve");
            var justin = new Developer("Justin");
            var jenna = new Developer("Jenna");
            var kim = new Tester("Kim");
            var julia = new Tester("Julia");

            teamchat.RegisterMembers(steve, justin, jenna, kim, julia);

            steve.Send("Hey everyone, we're going to be deploying at 2pm today");
            kim.Send("OK, thanks for letting me know");

            Console.WriteLine();
            steve.SendTo<Developer>("Make sure to execute your unit tests before checking in!");
        }
    }
}
