# Question 7: Take 10 numbers and find the average of all the prime numbers in the collection
def is_prime(num):
    """Function to check if a number is prime"""
    if num <= 1:
        return False
    for i in range(2, int(num**0.5) + 1):
        if num % i == 0:
            return False
    return True

numbers = []
for i in range(10):
    numbers.append(int(input(f"Enter number {i+1}: ")))

prime_numbers = [num for num in numbers if is_prime(num)]
1

if prime_numbers:
    print("Prime numbers: ", prime_numbers)
    print()
    average = sum(prime_numbers) / len(prime_numbers)
    print(f"Average of prime numbers: {average}")
else:
    print("No prime numbers found")
