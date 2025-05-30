using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ChainOfResponsibility.V1.Document;

namespace ChainOfResponsibility.V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Chain Of Responsibility";

            var validDocument = new Document("How to Avoid Java Deve;opment",
                DateTimeOffset.UtcNow, true, true);

            var inValidDocument = new Document("How to Avoid Java Deve;opment",
                DateTimeOffset.UtcNow, false, true);

            var documentHandlerChain = new DocumentTitleHandler();
            documentHandlerChain.SetSuccessor(new DocumentLastModifiedHandler())
                .SetSuccessor(new DocumentApprovedByLitigationHandler())
                .SetSuccessor(new DocumentApprovedByManagerHandler());

            try
            {
                documentHandlerChain.Handle(validDocument);
                Console.WriteLine("Valid Document is Valid");
                documentHandlerChain.Handle(validDocument);
                Console.WriteLine("Invalid Document is Invalid");
            }
            catch (ValidationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
