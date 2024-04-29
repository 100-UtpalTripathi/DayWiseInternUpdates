namespace Excel_Sheet_Column_Title
{
    internal class Program
    {
        public async Task<string> ConvertToTitle(int columnNumber)
        {
            string result = "";
            while (columnNumber > 0)
            {
                columnNumber--;
                result = (char)('A' + columnNumber % 26) + result;
                columnNumber /= 26;
            }
            return result;
        }
        static async Task Main(string[] args)
        {
            Console.WriteLine("Enter the number of test cases: ");
            int t = Convert.ToInt32(Console.ReadLine());

            Program p = new Program();
            while (t-- > 0)
            {
                Console.WriteLine("Enter the column number: ");
                int columnNumber = Convert.ToInt32(Console.ReadLine());
                
                Console.WriteLine("The column title is: " + await p.ConvertToTitle(columnNumber));
            }
        }
    }
}
