
# Write a function that checks if a given credit card number is valid or not. The function should return True if the card number is valid and False otherwise. The function should take a single argument, a string representing the card number. The card number should be passed as a single string, with no spaces. The function should return True if the card number is valid and False otherwise. The function should implement the Luhn algorithm to check if the card number is valid. The Luhn algorithm works as follows:
def luhn_check(card_number):

    # Remove spaces from the card number
    card_number = card_number.replace(" ", "")

    # Check if the card number is a valid number
    if not card_number.isdigit():
        return False

    total = 0

    # Reverse the card number
    reverse_digits = card_number[::-1]
    
    # Iterate through the digits of the reversed card number
    for i, digit in enumerate(reverse_digits):
        n = int(digit)

        # Double every Odd index after reversing the card number
        if i % 2 == 1:
            n *= 2

            # if doubling the digit results in a number greater than 9, subtract 9 from the result or add the digits
            if n > 9:
                n -= 9
        total += n

    # Check if the total is divisible by 10
    return total % 10 == 0

# Example usage
card_number = "4539 1488 0343 6467"
print("Is the card number valid?", luhn_check(card_number))
