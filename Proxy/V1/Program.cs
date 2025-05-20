namespace Proxy.V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Proxy";

            // without proxy
            Console.WriteLine("Constructing document.");
            var myDocument = new Proxy.V1.Document("MyDocument.pdf");
            Console.WriteLine("Document constructed.");
            myDocument.DisplayDocument();

            Console.WriteLine();

            // with proxy 
            Console.WriteLine("Constructing document proxy.");
            var myDocumentProxy = new Proxy.V1.DocumentProxy("MyDocument.pdf");
            Console.WriteLine("Document proxy constructed.");
            myDocumentProxy.DisplayDocument();

            Console.WriteLine();

            // with chained proxy
            Console.WriteLine("Constructing protected document proxy.");
            var myProtectedDocumentProxy = new Proxy.V1.ProtectedDocumentProxy("MyDocument.pdf", "Viewer");
            Console.WriteLine("Protected document proxy constructed.");
            myProtectedDocumentProxy.DisplayDocument();

            Console.WriteLine();

            // with chained proxy, no access
            Console.WriteLine("Constructing protected document proxy.");
            myProtectedDocumentProxy = new Proxy.V1.ProtectedDocumentProxy("MyDocument.pdf", "AnotherRole");
            Console.WriteLine("Protected document proxy constructed.");
            myProtectedDocumentProxy.DisplayDocument();

            Console.ReadKey();
        }
    }
}
