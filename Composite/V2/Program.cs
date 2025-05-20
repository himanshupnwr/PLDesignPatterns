using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //create a tree structure
            var root = new CompositeV2("root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            var comp1 = new CompositeV2("Composite C1");
            comp1.Add(new Leaf("Leaf C1-A"));
            comp1.Add(new Leaf("Leaf C1-B"));

            var comp2 = new CompositeV2("Composite C2");
            comp2.Add(new Leaf("Leaf C2-A"));
            comp1.Add(comp2);

            root.Add(comp1);
            root.Add(new Leaf("Leaf C"));

            //Add or remove a leaf
            var leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            //recursively display tree
            root.PrimaryOperation(1);
        }
    }
}
