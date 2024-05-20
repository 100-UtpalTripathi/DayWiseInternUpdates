using UnderstandingLINQApp.Models;

namespace UnderstandingLINQApp
{
    internal class Program
    {
        void executeQuery()
        {
            PubsContext context = new PubsContext();
            // Grouping the sales by TitleId and calculating the total quantity and order ids
            var salesGroupedByTitle = context.Sales
                                              .GroupBy(s => s.TitleId)
                                              .Select(g => new
                                              {
                                                  TitleId = g.Key,
                                                  TotalQuantity = g.Sum(s => s.Qty),
                                                  OrderIds = g.Select(s => s.OrdNum).ToList()
                                              })
                                              .ToList();

            // Printing the result
            foreach (var group in salesGroupedByTitle)
            {
                Console.WriteLine($"TitleId: {group.TitleId}, TotalQuantity: {group.TotalQuantity}");
                Console.WriteLine($"OrderIds: {string.Join(", ", group.OrderIds)}");
                Console.WriteLine();
            }
        }
        void PrintNumberOfBooksFromType(string type)
        {
            PubsContext context = new PubsContext();
            var bookCount = context.Titles.Where(t => t.Type == type).Count();
            Console.WriteLine($"There are {bookCount} in the type {type}");
        }
        void PrintAuthorNames()
        {
            PubsContext context = new PubsContext();
            var authors = context.Authors.ToList();
            foreach (var author in authors)
            {
                Console.WriteLine(author.AuFname + " " + author.AuLname);
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            //program.PrintAuthorNames();
            //program.PrintNumberOfBooksFromType("mod_cook");
            program.executeQuery();
        }
    }
}
