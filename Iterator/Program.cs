namespace Iterator
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Iterator";

            //create the collection
            PeopleCollection people = new PeopleCollection();
            people.Add(new Person("Kevin", "Belgium"));
            people.Add(new Person("Gill", "Belgium"));
            people.Add(new Person("Roland", "Belgium"));
            people.Add(new Person("Thomas", "Belgium"));

            //create the iterator
            var peopleIterator = people.CreateIterator();

            //use the iterator to run through the people in the
            //collection; they should come out in the alphabetical order
            for (Person person = peopleIterator.First();
                !peopleIterator.IsDone; 
                person = peopleIterator.Next())
            {
                {
                    Console.WriteLine(person.Name);
                }
            }
        }
    }
}
