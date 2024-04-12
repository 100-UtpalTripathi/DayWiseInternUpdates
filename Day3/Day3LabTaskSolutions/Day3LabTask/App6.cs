using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3LabTask
{
    internal class App6
    {
        static bool checkVowel(char ch)
        {
            if (ch == 'a' || ch == 'e' || ch == 'i' || ch == 'o' || ch == 'u')
                return true;
            else if (ch == 'A' || ch == 'E' || ch == 'I' || ch == 'O' || ch == 'U')
                return true;
            return false;
        }
        static int CountRepeatingVowels(string word)
        {
            int count = 0;

            for (int i = 0; i < word.Length; i++)
            {
                if (checkVowel(word[i]))
                {
                    int j = i + 1;
                    while (j < word.Length && word[j] == word[i])
                    {
                        count++;
                        j++;
                    }
                    i = j - 1;
                }
            }

            return count;
        }
        public void myMethod()
        {
            Console.WriteLine("Enter words separated by commas:");
            string input = Console.ReadLine();
            string[] words = input.Split(',');

            int minRepeatingVowels = int.MaxValue;
            var wordsWithMinRepeatingVowels = new System.Collections.Generic.List<string>();

            foreach (string word in words)
            {
                int repeatingVowels = CountRepeatingVowels(word);
                if (repeatingVowels < minRepeatingVowels)
                {
                    minRepeatingVowels = repeatingVowels;
                    wordsWithMinRepeatingVowels.Clear();
                    wordsWithMinRepeatingVowels.Add(word);
                }
                else if (repeatingVowels == minRepeatingVowels)
                {
                    wordsWithMinRepeatingVowels.Add(word);
                }
            }

            Console.WriteLine($"Words with the least repeating vowels ({minRepeatingVowels} repetitions):");
            foreach (string word in wordsWithMinRepeatingVowels)
            {
                Console.WriteLine($"{word} - {minRepeatingVowels} repetitions");
            }
        }
    }
}
