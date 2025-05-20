namespace Flyweight.V2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var drinkFactory = new DrinkFactory();
           
            var largeEspresso = drinkFactory.GetDrink("Espresso");
            largeEspresso.Serve("Large");

            var mediumSmoothie = drinkFactory.GetDrink("BananaSmoothie");
            mediumSmoothie.Serve("Medium");

            var smallEspresso = drinkFactory.GetDrink("Espresso");
            largeEspresso.Serve("Small");

            var smallSmoothie = drinkFactory.GetDrink("BananaSmoothie");
            mediumSmoothie.Serve("Small");

            var sizes = new string[] { "Small", "Medium", "Large" };

            foreach (var size in sizes) {
                var giveaway = drinkFactory.CreateGiveway();
                giveaway.Serve(size);
            }

            drinkFactory.ListDrinks();
        }
    }
}
