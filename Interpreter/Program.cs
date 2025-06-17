namespace Interpreter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Interpreter";

            var expressions = new List<RomanExpression>
            {
                new RomanHundredExpression(),
                new RomanTenExpression(),
                new RomanOneExpression()
            };
            var context = new RomanContext(5);
            foreach (var expression in expressions) {
                expression.Interpret(context);
            }
            Console.WriteLine($"Translating Arabic numerals to roman numerals: 5 = {context.Output}");

            context = new RomanContext(733);
            foreach (var expression in expressions)
            {
                expression.Interpret(context);
            }
            Console.WriteLine($"Translating Arabic numerals to roman numerals: 5 = {context.Output}");
        }
    }
}
