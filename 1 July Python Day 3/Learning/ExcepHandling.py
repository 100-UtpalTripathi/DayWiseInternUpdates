class NegativeValueError(Exception):
    """Custom exception for negative values."""
    pass

def divide(a, b):
    if b == 0:
        raise ZeroDivisionError("You can't divide by zero!")
    return a / b

def check_positive(value):
    if value < 0:
        raise NegativeValueError("Value cannot be negative!")
    return value

try:
    num1 = int(input("Enter the first number: "))
    num2 = int(input("Enter the second number: "))
    
    num1 = check_positive(num1)
    num2 = check_positive(num2)
    
    result = divide(num1, num2)
except ZeroDivisionError as zde:
    print(zde)
except NegativeValueError as nve:
    print(nve)
except ValueError:
    print("Invalid input! Please enter a valid number.")
else:
    print(f"The result of division is: {result}")
finally:
    print("Program execution completed.")
