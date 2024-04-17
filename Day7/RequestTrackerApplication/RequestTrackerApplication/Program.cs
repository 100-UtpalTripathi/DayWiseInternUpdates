using RequestTrackerModelLibrary;
using System.Collections;

namespace RequestTrackerApp
{
    internal class Program
    {
        void UnderstandingList()
        {
            List<int> list = new List<int>();
            list.Add(0);
            list.Add(1);
            list.Add(2);    
                
            list.Add(3);
            list.Add(4);
            list.Add(5);

            foreach(int num in list)
            {
                Console.WriteLine(num);
            }
        }
        static void Main(string[] args)
        {
            new Program().UnderstandingList();

        }
    }
}