# This Python program demonstrates various operations and characteristics of sets

# Creating a set
my_set = {"apple", "banana", "cherry"}
print("Original Set:", my_set)

# Sets do not allow duplicate elements
my_set_with_duplicates = {"apple", "banana", "cherry", "apple"}
print("Set with Duplicates:", my_set_with_duplicates)  # Output: {'banana', 'apple', 'cherry'}

# Adding an element to a set using add()
my_set.add("orange")
print("Set after Adding 'orange':", my_set)  # Output: {'banana', 'apple', 'orange', 'cherry'}

# Removing an element from a set using remove()
# If the element is not present, remove() raises a KeyError
try:
    my_set.remove("banana")
except KeyError as e:
    print("Error:", e)
print("Set after Removing 'banana':", my_set)  # Output: {'apple', 'orange', 'cherry'}

# Removing an element from a set using discard()
# If the element is not present, discard() does nothing
my_set.discard("grape")
print("Set after Discarding 'grape':", my_set)  # Output: {'apple', 'orange', 'cherry'}

# Removing and returning an arbitrary element from a set using pop()
popped_element = my_set.pop()
print("Popped Element:", popped_element)
print("Set after Popping an Element:", my_set)

# Clearing all elements from a set using clear()
my_set.clear()
print("Set after Clearing:", my_set)  # Output: set()

# Creating a set from a list
my_list = [1, 2, 3, 4, 5]
my_set_from_list = set(my_list)
print("Set from List:", my_set_from_list)  # Output: {1, 2, 3, 4, 5}

# Set operations: Union
set1 = {1, 2, 3}
set2 = {3, 4, 5}
union_set = set1.union(set2)
print("Union of set1 and set2:", union_set)  # Output: {1, 2, 3, 4, 5}

# Set operations: Intersection
intersection_set = set1.intersection(set2)
print("Intersection of set1 and set2:", intersection_set)  # Output: {3}

# Set operations: Difference
difference_set = set1.difference(set2)
print("Difference of set1 and set2:", difference_set)  # Output: {1, 2}

# Set operations: Symmetric Difference
symmetric_difference_set = set1.symmetric_difference(set2)
print("Symmetric Difference of set1 and set2:", symmetric_difference_set)  # Output: {1, 2, 4, 5}

# Checking if a set is a subset of another set using issubset()
subset = {1, 2}
is_subset = subset.issubset(set1)
print("Is subset a subset of set1?:", is_subset)  # Output: True

# Checking if a set is a superset of another set using issuperset()
is_superset = set1.issuperset(subset)
print("Is set1 a superset of subset?:", is_superset)  # Output: True

# Checking if two sets are disjoint using isdisjoint()
disjoint_set = {6, 7, 8}
are_disjoint = set1.isdisjoint(disjoint_set)
print("Are set1 and disjoint_set disjoint?:", are_disjoint)  # Output: True

# Iterating over a set
for element in set1:
    print("Set Element:", element)
    # Output:
    # Set Element: 1
    # Set Element: 2
    # Set Element: 3

# Set comprehensions
squared_set = {x**2 for x in set1}
print("Squared Set:", squared_set)  # Output: {1, 4, 9}

# Frozen sets: Immutable sets
frozen_set = frozenset([1, 2, 3, 4])
print("Frozen Set:", frozen_set)
# Attempting to add or remove elements from a frozen set will result in an error
try:
    frozen_set.add(5)
except AttributeError as e:
    print("Error:", e)  # Output: 'frozenset' object has no attribute 'add'
