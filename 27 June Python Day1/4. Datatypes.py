# Example: Python Data Types

# 1. Integers
# Whole numbers without a decimal point
age = 30
print("Integer:", age)

# 2. Floats
# Numbers with a decimal point
price = 19.99
print("Float:", price)

# 3. Strings
# Sequence of characters enclosed in single or double quotes
name = "Alice"
greeting = 'Hello, World!'
print("String:", name)
print("String:", greeting)

# 4. Booleans
# True or False values
is_active = True
is_logged_in = False
print("Boolean:", is_active)
print("Boolean:", is_logged_in)

# 5. Lists
# Ordered collection of items, can be of mixed types
fruits = ["apple", "banana", "cherry"]
mixed_list = [1, "hello", 3.14, True]
print("List:", fruits)
print("Mixed List:", mixed_list)

# Accessing list elements
print("First fruit:", fruits[0])  # Indexing starts from 0

# Modifying list elements
fruits[1] = "blueberry"
print("Modified List:", fruits)

# 6. Tuples
# Ordered collection of items, immutable (cannot be changed)
coordinates = (10.0, 20.0)
person = ("Alice", 30, "Engineer")
print("Tuple:", coordinates)
print("Tuple:", person)

# Accessing tuple elements
print("First coordinate:", coordinates[0])

# 7. Sets
# Unordered collection of unique items
unique_numbers = {1, 2, 3, 4, 4, 5}
print("Set:", unique_numbers)  # Duplicate 4 will be removed

# Adding and removing elements in a set
unique_numbers.add(6)
unique_numbers.remove(2)
print("Modified Set:", unique_numbers)

# 8. Dictionaries
# Collection of key-value pairs
person_info = {"name": "Alice", "age": 30, "job": "Engineer"}
print("Dictionary:", person_info)

# Accessing dictionary elements
print("Name:", person_info["name"])

# Modifying dictionary elements
person_info["age"] = 31
print("Modified Dictionary:", person_info)

# 9. NoneType
# Represents the absence of a value
nothing = None
print("NoneType:", nothing)

# 10. Complex Numbers
# Numbers with a real and imaginary part
complex_num = 3 + 5j
print("Complex Number:", complex_num)
print("Real part:", complex_num.real)
print("Imaginary part:", complex_num.imag)

# Example Operations on Data Types

# Arithmetic operations on numbers
a = 10
b = 3
print("Addition:", a + b)
print("Subtraction:", a - b)
print("Multiplication:", a * b)
print("Division:", a / b)
print("Integer Division:", a // b)
print("Modulus:", a % b)
print("Exponentiation:", a ** b)

# String concatenation and repetition
str1 = "Hello"
str2 = "World"
print("Concatenation:", str1 + " " + str2)
print("Repetition:", str1 * 3)

# List operations
numbers = [1, 2, 3, 4, 5]
print("Length of list:", len(numbers))
print("Sum of list:", sum(numbers))
numbers.append(6)
print("List after append:", numbers)
numbers.remove(3)
print("List after remove:", numbers)

# Dictionary operations
print("Keys:", person_info.keys())
print("Values:", person_info.values())
print("Items:", person_info.items())

# Set operations
set_a = {1, 2, 3}
set_b = {3, 4, 5}
print("Union:", set_a | set_b)
print("Intersection:", set_a & set_b)
print("Difference:", set_a - set_b)
print("Symmetric Difference:", set_a ^ set_b)
