# Example 1: Basic Input
# Prompt the user to enter their name and greet them

name = input("Enter your name: ")
print("Hello, " + name + "!")

# Example 2: Converting Input
# Prompt the user to enter their age and convert it to an integer

age = input("Enter your age: ")
age = int(age)  # Convert the input to an integer
print("You are " + str(age) + " years old.")

# Example 3: Handling Multiple Inputs
# Prompt the user to enter their first name and last name separately

# Multiple calls
first_name = input("Enter your first name: ")
last_name = input("Enter your last name: ")
print("Your full name is " + first_name + " " + last_name + ".")

# Using split
full_name = input("Enter your full name: ")
first_name, last_name = full_name.split()
print("Your first name is " + first_name + " and your last name is " + last_name + ".")

# Example 4: Simple Calculator
# A simple calculator that takes user input for two numbers and an operator, then performs the operation

# Get the first number
num1 = float(input("Enter the first number: "))

# Get the second number
num2 = float(input("Enter the second number: "))

# Get the operation
operation = input("Enter an operation (+, -, *, /): ")

# Perform the calculation
if operation == '+':
    result = num1 + num2
elif operation == '-':
    result = num1 - num2
elif operation == '*':
    result = num1 * num2
elif operation == '/':
    if num2 != 0:
        result = num1 / num2
    else:
        result = "Error! Division by zero."
else:
    result = "Invalid operation!"

print("The result is:", result)

# Example 5: Handling Invalid Input
# Handle invalid input by using a loop and exception handling

while True:
    try:
        num = int(input("Enter an integer: "))
        break  # Exit the loop if the input is valid
    except ValueError:
        print("Invalid input! Please enter a valid integer.")

print("You entered:", num)
