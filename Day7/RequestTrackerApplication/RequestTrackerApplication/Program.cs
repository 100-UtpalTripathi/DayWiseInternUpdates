using RequestTrackerModelLibrary;
using System.Collections;

namespace RequestTrackerApp
{
    internal class Program
    {
        void UnderstaingList()
        {
            ArrayList list = new ArrayList();
            list.Add(100);
            list.Add("Hiiii");
            list.Add(23.4);
            list.Add(90.3f);
            list.Add(new Employee(101, "Stuart", new DateTime(), "HR"));
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine(list[i]);
            }
        }
        static void Main(string[] args)
        {
            new Program().UnderstaingList();

        }
    }
}