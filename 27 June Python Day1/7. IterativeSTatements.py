# Example: Iterative Statements in Python

# Example 1: for Loop
# Iterates over a sequence (e.g., list, tuple, string) or iterator

# Iterating over a list
print("Example 1: for Loop - Iterating over a list")
fruits = ["apple", "banana", "cherry"]
for fruit in fruits:
    print(fruit)
print()

# Iterating over a string
print("Example 1: for Loop - Iterating over a string")
for char in "Hello":
    print(char)
print()

# Iterating over a range of numbers
print("Example 1: for Loop - Iterating over a range of numbers")
for i in range(5):
    print(i)
print()

# Example 2: while Loop
# Executes a block of code as long as a specified condition is true

# Using a while loop to print numbers from 1 to 5
print("Example 2: while Loop - Printing numbers from 1 to 5")
num = 1
while num <= 5:
    print(num)
    num += 1
print()

# Using a while loop to find factorial of a number
print("Example 2: while Loop - Calculating factorial of 5")
num = 5
factorial = 1
while num > 0:
    factorial *= num
    num -= 1
print("Factorial:", factorial)
print()

# Using a while loop with break and continue statements
print("Example 2: while Loop - Using break and continue")
num = 0
while num < 10:
    num += 1
    if num % 2 == 0:
        continue  # Skip even numbers
    if num > 5:
        break  # Exit loop when num exceeds 5
    print(num)
print()

# Example 3: Nested Loops
# Using nested loops to iterate over a 2D list (matrix)

print("Example 3: Nested Loops - Iterating over a 2D list")
matrix = [[1, 2, 3],
          [4, 5, 6],
          [7, 8, 9]]

for row in matrix:
    for element in row:
        print(element, end=" ")
    print()
print()

# Example 4: Iterating over Dictionaries
# Iterating over keys, values, and key-value pairs in a dictionary

print("Example 4: Iterating over a Dictionary")
person_info = {"name": "Alice", "age": 30, "job": "Engineer"}

# Iterating over keys
print("Keys:")
for key in person_info:
    print(key)

# Iterating over values
print("\nValues:")
for value in person_info.values():
    print(value)

# Iterating over key-value pairs
print("\nKey-Value Pairs:")
for key, value in person_info.items():
    print(f"{key}: {value}")
