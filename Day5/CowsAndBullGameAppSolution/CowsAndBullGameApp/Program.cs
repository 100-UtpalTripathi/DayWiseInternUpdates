namespace CowsAndBullGameApp
{
    internal class Program
    {
        static void PlayGame(string wordToGuess)
        {
            int attempts = 0;

            while (true)
            {
                attempts++;
                Console.WriteLine($"Attempt #{attempts}:");
                string guess = GetGuessFromUser();

                int cows, bulls;
                CheckGuess(wordToGuess, guess, out cows, out bulls);

                Console.WriteLine($"Cows: {cows}, Bulls: {bulls}");

                if (cows == 4)
                {
                    Console.WriteLine("Congrats!!! You won!!!!!");
                    break;
                }
            }
        }

        static string GetInputFromUser()
        {
            string secret;
            do
            {
                Console.Write("\nEnter your 4 characters Secret Word: ");
                secret = Console.ReadLine().Trim().ToLower();
            } while (secret.Length != 4);

            return secret;
        }

        static string GetGuessFromUser()
        {
            string guess;
            do
            {
                Console.WriteLine("Enter your 4 character Guess word: ");
                guess = Console.ReadLine().Trim().ToLower();
            } while (guess.Length != 4);

            return guess;
        }

        static void CheckGuess(string wordToGuess, string guess, out int cows, out int bulls)
        {
            cows = 0;
            bulls = 0;

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (guess[i] == wordToGuess[i])
                {
                    cows++;
                }
                else if (wordToGuess.Contains(guess[i]))
                {
                    bulls++;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("     $$   Welcome to Cow and Bull game!  $$     ");
            string wordToGuess = GetInputFromUser();
            Console.WriteLine($"Word to guess: {wordToGuess}");

            PlayGame(wordToGuess);
        }

    }
}
