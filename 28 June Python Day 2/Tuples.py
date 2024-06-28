# This Python program demonstrates various operations and characteristics of tuples

# Creating a tuple
my_tuple = ("apple", "banana", "cherry")
print("Original Tuple:", my_tuple)

# Accessing tuple elements by index
first_element = my_tuple[0]
print("First Element:", first_element)  # Output: apple

# Negative indexing
last_element = my_tuple[-1]
print("Last Element:", last_element)  # Output: cherry

# Slicing a tuple
# Syntax: tuple[start:end]
sub_tuple = my_tuple[1:3]
print("Sub Tuple (Slicing):", sub_tuple)  # Output: ('banana', 'cherry')

# Tuples are immutable, meaning their elements cannot be changed
# Attempting to change an element will result in an error
try:
    my_tuple[0] = "orange"
except TypeError as e:
    print("Error:", e)  # Output: 'tuple' object does not support item assignment

# Concatenating tuples
tuple1 = (1, 2, 3)
tuple2 = (4, 5, 6)
concatenated_tuple = tuple1 + tuple2
print("Concatenated Tuple:", concatenated_tuple)  # Output: (1, 2, 3, 4, 5, 6)

# Repeating a tuple using the * operator
repeated_tuple = tuple1 * 3
print("Repeated Tuple:", repeated_tuple)  # Output: (1, 2, 3, 1, 2, 3, 1, 2, 3)

# Checking if an element exists in a tuple using 'in'
is_banana_in_tuple = "banana" in my_tuple
print("Is 'banana' in my_tuple?:", is_banana_in_tuple)  # Output: True

# Getting the length of a tuple using len()
tuple_length = len(my_tuple)
print("Length of my_tuple:", tuple_length)  # Output: 3

# Tuples can contain elements of different types
mixed_tuple = ("hello", 3.14, True, [1, 2, 3])
print("Mixed Tuple:", mixed_tuple)  # Output: ('hello', 3.14, True, [1, 2, 3])

# Nested tuples
nested_tuple = (("a", "b"), (1, 2, 3), ("x", "y", "z"))
print("Nested Tuple:", nested_tuple)  # Output: (('a', 'b'), (1, 2, 3), ('x', 'y', 'z'))

# Accessing elements in a nested tuple
first_nested_element = nested_tuple[0]
print("First Nested Element:", first_nested_element)  # Output: ('a', 'b')

# Accessing elements within a nested tuple
first_element_of_first_nested_tuple = nested_tuple[0][0]
print("First Element of First Nested Tuple:", first_element_of_first_nested_tuple)  # Output: a

# Using tuples in a loop
for item in my_tuple:
    print("Loop Item:", item)
    # Output:
    # Loop Item: apple
    # Loop Item: banana
    # Loop Item: cherry

# Converting a list to a tuple using tuple()
my_list = [1, 2, 3]
converted_tuple = tuple(my_list)
print("Converted Tuple from List:", converted_tuple)  # Output: (1, 2, 3)

# Converting a tuple to a list using list()
converted_list = list(my_tuple)
print("Converted List from Tuple:", converted_list)  # Output: ['apple', 'banana', 'cherry']

# Finding the index of an element in a tuple using index()
index_of_banana = my_tuple.index("banana")
print("Index of 'banana':", index_of_banana)  # Output: 1

# Counting the occurrences of an element in a tuple using count()
count_of_apple = my_tuple.count("apple")
print("Count of 'apple':", count_of_apple)  # Output: 1
