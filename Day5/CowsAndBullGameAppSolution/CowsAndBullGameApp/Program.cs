using System;

namespace CowsAndBullGameApp
{
    internal class Program
    {
        /// <summary>
        /// Plays the Cow and Bull game.
        /// </summary>
        /// <param name="wordToGuess">The word to be guessed by the player.</param>
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

        /// <summary>
        /// Gets a 4-character word from the user.
        /// </summary>
        /// <returns>The 4-character word entered by the user.</returns>
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

        /// <summary>
        /// Gets a 4-character guess from the user.
        /// </summary>
        /// <returns>The 4-character guess entered by the user.</returns>
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

        /// <summary>
        /// Checks the guess against the word to guess and calculates cows and bulls.
        /// </summary>
        /// <param name="wordToGuess">The word to be guessed.</param>
        /// <param name="guess">The guess made by the player.</param>
        /// <param name="cows">The number of correct characters in correct positions.</param>
        /// <param name="bulls">The number of correct characters in wrong positions.</param>
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

        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("     $$   Welcome to Cow and Bull game!  $$     ");
            string wordToGuess = GetInputFromUser();
            Console.WriteLine($"Word to guess: {wordToGuess}");

            PlayGame(wordToGuess);
        }
    }
}
