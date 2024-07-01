# main.py

# Import the entire module
import my_module

# Using functions from the module
result1 = my_module.add(10, 5)
result2 = my_module.subtract(10, 5)
print(f"10 + 5 = {result1}")
print(f"10 - 5 = {result2}")

# Using the Car class from the module
my_car = my_module.Car('Toyota', 'Corolla', 2020)
print(my_car.describe())

# Import specific functions and classes from the module
from my_module import add, Car

# Using the imported functions and classes
result3 = add(20, 10)
print(f"20 + 10 = {result3}")

my_second_car = Car('Honda', 'Civic', 2019)
print(my_second_car.describe())
