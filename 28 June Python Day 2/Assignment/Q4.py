import random

# Function to generate a random word from a list
def generate_random_word():
    # Sample word list
    word_list = ["apple", "banjo", "cider", "dough", "eagle"]
    return random.choice(word_list)

# Function to calculate cows and bulls
def cows_and_bulls(guess, secret_word):
    cows = bulls = 0
    for i in range(len(guess)):
        if guess[i] == secret_word[i]:
            bulls += 1
        elif guess[i] in secret_word:
            cows += 1
    return cows, bulls

# Function to play the game
def play_game():
    secret_word = generate_random_word()
    attempts = 0

    print("Welcome to the Cow and Bull Game!")
    print("Try to guess the 5-letter word.")

    while True:
        guess = input("Enter your guess: ").lower()
        if len(guess) != 5:
            print("Please enter a 5-letter word.")
            continue

        attempts += 1
        cows, bulls = cows_and_bulls(guess, secret_word)
        print(f"{cows} Cows, {bulls} Bulls")

        if bulls == 5:
            print(f"Congratulations! You guessed the word '{secret_word}' in {attempts} attempts.")
            break

# Example usage
play_game()
