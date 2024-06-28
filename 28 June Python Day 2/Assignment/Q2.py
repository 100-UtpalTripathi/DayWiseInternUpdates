
# Define a function that takes an integer n as input and returns a list of all prime numbers up to n.

def is_prime(num):
    if num <= 1:
        return False
    
    # Check for factors up to the square root of the number
    for i in range(2, int(num**0.5) + 1):
        if num % i == 0:
            return False
    return True

# Function to return a list of prime numbers up to n
def primes_up_to(n):
    primes = []
    for i in range(2, n + 1):
        if is_prime(i):
            primes.append(i)
    return primes

# Example
n = 20
print("Prime numbers up to", n, ":", primes_up_to(n))
