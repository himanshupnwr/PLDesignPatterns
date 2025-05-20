namespace Flyweight.V2
{
    public class DrinkFactory
    {
        private Dictionary<string, IDrinkFlyweight> _flyweightCache = new Dictionary<string, IDrinkFlyweight>();
        public int ObjectCreated = 0;

        public IDrinkFlyweight GetDrink(string drinkKey)
        {
            IDrinkFlyweight drinkFlyweight = null;

            if (_flyweightCache.ContainsKey(drinkKey))
            {
                Console.WriteLine("Reusing existing flyweight object");
                return _flyweightCache[drinkKey];
            }

            Console.WriteLine("New Drink flyweight object construction");
            switch (drinkKey)
            {
                case "Espresso":
                    drinkFlyweight = new Espresso();
                    break;
                case "BananaSmoothie":
                    drinkFlyweight = new BananaSmoothie();
                    break;
                default:
                    throw new Exception("This is not a flyweight drink object");
            }

            _flyweightCache.Add(drinkKey, drinkFlyweight);
            ObjectCreated++;

            return drinkFlyweight;
        }

        public IDrinkFlyweight CreateGiveway()
        {
            return new DrinkGiveaway();
        }

        public void ListDrinks()
        {
            Console.WriteLine($"\n Factory has {_flyweightCache.Count} drink objects ready to use");
            Console.WriteLine($"\n Number of objects created {ObjectCreated}");

            foreach(var drink in _flyweightCache)
            {
                Console.Write(drink.Value.Name);
            }

            Console.WriteLine("\n");
        }
    }
}
