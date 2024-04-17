using RequestTrackerModelLibrary;
using System.Collections;

namespace RequestTrackerApp
{
    internal class Program
    {
        void UnderstandingMap()
        {
            Dictionary<string, int> myMap = new Dictionary<string, int>();

            // Adding key-value pairs to the map
            myMap.Add("apple", 10);
            myMap.Add("banana", 5);
            myMap.Add("orange", 8);

            // Adding a key-value pair with an existing key (it will overwrite the previous value)
            myMap["banana"] = 7;

            // Accessing values by keys
            Console.WriteLine("The value of 'apple': " + myMap["apple"]); // 10

            // Checking if a key exists in the map
            Console.WriteLine("Is 'banana' a key in the map? " + myMap.ContainsKey("banana")); // true
            Console.WriteLine("Is 'grape' a key in the map? " + myMap.ContainsKey("grape")); // false

            // Iterating through the map
            Console.WriteLine("Map elements:");
            foreach (KeyValuePair<string, int> pair in myMap)
            {
                Console.WriteLine("Key: " + pair.Key + ", Value: " + pair.Value);
            }
        }
        static void Main(string[] args)
        {
            new Program().UnderstandingMap();

        }
    }
}