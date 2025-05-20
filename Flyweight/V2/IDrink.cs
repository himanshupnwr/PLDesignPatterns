using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Flyweight.V2
{
    public interface IDrinkFlyweight
    {
        //Intrinsic state - shared/readonly
        string Name { get; }

        //Extrinsic state
        void Serve(string size);
    }

    public class Espresso : IDrinkFlyweight
    {
        private string _name;
        public string Name => _name;
        private IEnumerable<string> _ingredients;

        public Espresso()
        {
            _name = "Espresso";
            _ingredients = new List<string>()
            {
                "Coffee Beans", 
                "Hot Water"
            };
        }

        public void Serve(string size)
        {
            Console.WriteLine($"- {size} {_name} with {string.Join(",", _ingredients)} coming up!");
        }
    }

    public class BananaSmoothie : IDrinkFlyweight
    {
        private string _name;
        public string Name => _name;
        private IEnumerable<string> _ingredients;

        public BananaSmoothie()
        {
            _name = "BananaSmoothie";
            _ingredients = new List<string>()
            {
                "Banana",
                "Cold Milk",
                "Vanilla Extract"
            };
        }

        public void Serve(string size)
        {
            Console.WriteLine($"- {size} {_name} with {string.Join(",", _ingredients)} coming up!");
        }
    }

    //Unshared Concrete Flyqeight
    public class DrinkGiveaway : IDrinkFlyweight
    {
        private IDrinkFlyweight _randomDrink;
        public string Name => _randomDrink.Name;
        private IDrinkFlyweight[] _eligibleDrinks = new IDrinkFlyweight[]
        {
            new Espresso(),
            new BananaSmoothie()
        };
        private string _size;

        public DrinkGiveaway()
        {
            var randomIndex = new Random().Next( 0, 2 );
            _randomDrink = _eligibleDrinks[randomIndex];
        }

        public void Serve(string size)
        {
            Console.WriteLine("Free Giveaway");
            Console.WriteLine($"- {size} {_randomDrink.Name} coming up!");
        }
    }
}
