# Example 1: Basic Output
# Print a simple string to the console

print("Hello, World!")

# Example 2: Output Variables
# Print variables, including strings and numbers

name = "Alice"
age = 30
print("Name:", name)
print("Age:", age)

# Example 3: Concatenating Strings
# Combine multiple strings using the + operator

first_name = "Alice"
last_name = "Smith"
full_name = first_name + " " + last_name
print("Full Name:", full_name)

# Example 4: Using Format Specifiers
# Format strings using the % operator

temperature = 23.456
print("The temperature is %.2f degrees Celsius" % temperature)

# Example 5: Using str.format()
# Format strings using the str.format() method

item = "apples"
count = 5
price = 1.23
print("I bought {} {} for ${:.2f}".format(count, item, price))

# Example 6: f-Strings (Python 3.6+)
# Format strings using f-strings for easier and more readable code

name = "Alice"
age = 30
print(f"Name: {name}, Age: {age}")

# Example 7: Printing Multiple Items
# Print multiple items in one print statement, separated by commas

name = "Alice"
age = 30
print("Name:", name, "Age:", age)

# Example 8: Customizing Separator and End Parameters
# Customize the separator between items and the end character

print("Alice", "Bob", "Charlie", sep=", ")
print("Hello", end=" ")
print("World")

# Example 9: Printing with Different Data Types
# Print lists, dictionaries, and other data structures

fruits = ["apple", "banana", "cherry"]
person = {"name": "Alice", "age": 30}
print("Fruits:", fruits)
print("Person:", person)

# Example 10: Printing Unicode Characters
# Print Unicode characters, such as emoji

print("Hello, World! 🌍")
