using System.CodeDom.Compiler;
using System.Text.Json;
using System.Xml;

namespace Composite.V1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using builder pattern
            var builder = new FileSystemBuilder("development", 0);
            builder.AddFile("toplevel.txt", 100);
            builder.AddDirectory("topleveldirectory1", 4);
            builder.AddFile("sublevel1.txt", 200);
            builder.AddFile("sublevel2.txt", 150);
            builder.SetCurrentDirectory("development");
            builder.AddDirectory("topleveldirectory2", 4);
            builder.AddFile("sublevel1.txt", 300);
            builder.AddFile("sublevel2.txt", 250);
            Console.WriteLine($"Size of root: {builder.Root.GetSize()}");
            Console.WriteLine(JsonSerializer.Serialize(builder.Root, new JsonSerializerOptions() { WriteIndented = true }));

            Console.Title = "Composite";

            var root = new Directory("root", 0);
            var topLevelFile = new File("toplevel.txt", 100);
            var topLevelDirectory1 = new Directory("topleveldirectory1", 4);
            var topLevelDirectory2 = new Directory("topleveldirectory2", 4);

            root.Add(topLevelFile);
            root.Add(topLevelDirectory1);
            root.Add(topLevelDirectory2);

            var subLevelFile1 = new File("sublevel1.txt", 200);
            var subLevelFile2 = new File("sublevel2.txt", 150);

            topLevelDirectory2.Add(subLevelFile1);
            topLevelDirectory2.Add(subLevelFile2);

            Console.WriteLine($"Size of topLevelDirectory1: {topLevelDirectory1.GetSize()}");
            Console.WriteLine($"Size of topLevelDirectory2: {topLevelDirectory2.GetSize()}");
            Console.WriteLine($"Size of root: {root.GetSize()}");

            Console.ReadKey();
        }
    }
}