using RequestTrackerModelLibrary;
using System.Collections;

namespace RequestTrackerApp
{
    internal class Program
    {
        void UnderstandingSet()
        {
            HashSet<int> mySet = new HashSet<int>();

            // Adding elements to the set
            mySet.Add(5);
            mySet.Add(10);
            mySet.Add(15);

            // Adding a duplicate element (it will be ignored)
            mySet.Add(10);

            // Checking if an element exists in the set
            Console.WriteLine("Is 5 in the set? " + mySet.Contains(5)); // true
            Console.WriteLine("Is 20 in the set? " + mySet.Contains(20)); // false

            // Iterating through the set
            Console.WriteLine("Set elements:");
            foreach (int item in mySet)
            {
                Console.WriteLine(item);
            }
        }
        static void Main(string[] args)
        {
            new Program().UnderstandingSet();

        }
    }
}