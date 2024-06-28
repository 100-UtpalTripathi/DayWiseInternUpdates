# This Python program demonstrates various operations and characteristics of dictionaries

# Creating a dictionary
my_dict = {
    "name": "Alice",
    "age": 25,
    "city": "New York"
}
print("Original Dictionary:", my_dict)

# Accessing dictionary values by key
name = my_dict["name"]
print("Name:", name)  # Output: Alice

# Using the get() method to access dictionary values
# This method returns None if the key does not exist
age = my_dict.get("age")
print("Age:", age)  # Output: 25
country = my_dict.get("country")
print("Country:", country)  # Output: None

# Adding a new key-value pair to the dictionary
my_dict["email"] = "alice@example.com"
print("Dictionary after Adding Email:", my_dict)

# Updating the value of an existing key
my_dict["age"] = 26
print("Dictionary after Updating Age:", my_dict)

# Removing a key-value pair using del
del my_dict["city"]
print("Dictionary after Deleting City:", my_dict)

# Removing a key-value pair using pop()
# The pop() method returns the value of the removed key
removed_value = my_dict.pop("email")
print("Removed Value:", removed_value)  # Output: alice@example.com
print("Dictionary after Popping Email:", my_dict)

# Checking if a key exists in a dictionary using in
has_name = "name" in my_dict
print("Does 'name' Exist in Dictionary?:", has_name)  # Output: True

# Iterating over dictionary keys
print("Dictionary Keys:")
for key in my_dict:
    print(key)
    # Output:
    # name
    # age

# Iterating over dictionary values
print("Dictionary Values:")
for value in my_dict.values():
    print(value)
    # Output:
    # Alice
    # 26

# Iterating over dictionary key-value pairs
print("Dictionary Items:")
for key, value in my_dict.items():
    print(key, ":", value)
    # Output:
    # name : Alice
    # age : 26

# Creating a dictionary using the dict() constructor
another_dict = dict(
    brand="Ford",
    model="Mustang",
    year=1964
)
print("Another Dictionary:", another_dict)

# Using dictionary comprehension
squared_numbers = {x: x*x for x in range(1, 6)}
print("Squared Numbers Dictionary:", squared_numbers)  # Output: {1: 1, 2: 4, 3: 9, 4: 16, 5: 25}

# Merging two dictionaries using the update() method
dict1 = {"a": 1, "b": 2}
dict2 = {"b": 3, "c": 4}
dict1.update(dict2)
print("Merged Dictionary using update():", dict1)  # Output: {'a': 1, 'b': 3, 'c': 4}

# Copying a dictionary using the copy() method
original_dict = {"one": 1, "two": 2}
copied_dict = original_dict.copy()
print("Copied Dictionary:", copied_dict)  # Output: {'one': 1, 'two': 2}

# Nested dictionaries
nested_dict = {
    "child1": {
        "name": "John",
        "year": 2004
    },
    "child2": {
        "name": "Marie",
        "year": 2007
    }
}
print("Nested Dictionary:", nested_dict)
print("Child1's Name:", nested_dict["child1"]["name"])  # Output: John

# Clearing all elements from a dictionary using clear()
original_dict.clear()