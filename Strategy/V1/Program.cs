using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy.V1
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Strategy";
            //passing the strategy using method parameter approch
            var order = new Order("Marvin Software", 5, "Visual Studio License", new JsonExportStrategy());
            
            //passing the strategy using class property approach
            //order.ExportStrategy = new JsonExportStrategy();
            order.Export();
        }
    }
}
