# Example: Conditional Statements in Python

# Example 1: Simple if Statement
# Checks if a number is positive

num = 10
if num > 0:
    print("Example 1: num is positive")
print()

# Example 2: if...else Statement
# Checks if a number is positive or not

num = -5
if num > 0:
    print("Example 2: num is positive")
else:
    print("Example 2: num is not positive")
print()

# Example 3: if...elif...else Statement
# Checks if a number is positive, negative, or zero

num = 0
if num > 0:
    print("Example 3: num is positive")
elif num < 0:
    print("Example 3: num is negative")
else:
    print("Example 3: num is zero")
print()

# Example 4: Nested if Statements
# Checks if a number is positive and even

num = 10
if num > 0:
    if num % 2 == 0:
        print("Example 4: num is a positive even number")
    else:
        print("Example 4: num is a positive odd number")
else:
    print("Example 4: num is not a positive number")
print()

# Example 5: Logical Operators with Conditional Statements
# Checks if a person is eligible to work based on age

age = 25
if age >= 18 and age <= 65:
    print("Example 5: You are eligible to work")
else:
    print("Example 5: You are not eligible to work")
print()

# Example 6: Ternary Operator (Conditional Operator)
# Checks if a number is even or odd using a ternary operator

num = 10
even_odd = "even" if num % 2 == 0 else "odd"
print(f"Example 6: {num} is {even_odd}")
print()

# Match Statement (Python 3.10+)

animal = "Eagle"  
match animal:     # Match statement
    case "Eagle" | "Parrot":    # Multiple patterns
        print("Bird")
    case "Lion" | "Tiger":
        print("Mammal")
    case "Python" | "Crocodile":
        print("Reptile")
    case _:                # Default case
        print("Unknown Class")