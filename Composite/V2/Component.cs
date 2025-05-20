using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.V2
{
    public abstract class Component
    {
        public Component(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public abstract void PrimaryOperation(int depth);
    }

    public class Leaf : Component
    {

        public Leaf(string name): base(name)
        {
            
        }
      

        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new String('-', depth) + this.Name);
        }

       
    }

    public class CompositeV2 : Component
    {
        private List<Component> children = new List<Component>();
        public CompositeV2(string name) : base(name)
        {

        }
        public void Add(Component c)
        {
            this.children.Add(c);
        }

        public override void PrimaryOperation(int depth)
        {
            Console.WriteLine(new String('-', depth) + this.Name);
            foreach (Component c in children) { 
                c.PrimaryOperation(depth + 2);
            }
        }

        public void Remove(Component c)
        {
            this.children.Remove(c);
        }
    }
}
