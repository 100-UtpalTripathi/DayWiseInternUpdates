# Example: Functions in Python

# Example 1: Creating and Calling a Function
# Simple function to greet the user

def greet():
    """Function to print a greeting message"""
    print("Hello, welcome!")

# Calling the function
print("Example 1: Creating and Calling a Function")
greet()
print()

# Example 2: Function with Parameters
# Function to calculate the area of a rectangle

def calculate_area(length, width):
    """Function to calculate the area of a rectangle"""
    area = length * width
    return area

# Calling the function with arguments
print("Example 2: Function with Parameters")
length = 5
width = 3
area = calculate_area(length, width)
print(f"Area of rectangle with length {length} and width {width} is:", area)
print()

# Example 3: Function with Default Parameters
# Function to greet the user with a customizable message

def greet_user(name, message="Hello"):
    """Function to greet the user with a customizable message"""
    print(f"{message}, {name}!")

# Calling the function with and without message parameter
print("Example 3: Function with Default Parameters")
greet_user("Alice")
greet_user("Bob", "Hi")
print()

# Example 4: Function with Variable Number of Arguments
# Function to sum variable number of integers

def sum_numbers(*args):
    """Function to sum variable number of integers"""
    total = 0
    for num in args:
        total += num
    return total

# Calling the function with different number of arguments
print("Example 4: Function with Variable Number of Arguments")
print("Sum of 1, 2, 3:", sum_numbers(1, 2, 3))
print("Sum of 1, 2, 3, 4, 5:", sum_numbers(1, 2, 3, 4, 5))
print()

# Example 5: Function with Keyword Arguments
# Function to display user information

def display_info(name, age, **kwargs):
    """Function to display user information"""
    print(f"Name: {name}, Age: {age}")
    for key, value in kwargs.items():
        print(f"{key}: {value}")

# Calling the function with keyword arguments
print("Example 5: Function with Keyword Arguments")
display_info("Alice", 30, city="New York", profession="Engineer")
print()


# Example 6: Lambda Functions (Anonymous Functions)
# Using lambda function to calculate square of a number

print("Example 7: Lambda Function (Anonymous Function)")
square = lambda x: x ** 2
print("Square of 5 is:", square(5))
print()

# Example 7: Function as an Argument to Another Function
# Function to apply another function to a list of numbers

def apply_function(numbers, func):
    """Function to apply another function to a list of numbers"""
    result = []
    for num in numbers:
        result.append(func(num))
    return result

# Applying square function using apply_function
print("Example 8: Function as an Argument to Another Function")
numbers = [1, 2, 3, 4, 5]
print("Applying square function to numbers:", apply_function(numbers, lambda x: x ** 2))
