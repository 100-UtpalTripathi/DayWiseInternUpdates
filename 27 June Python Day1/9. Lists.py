# Example: Python Lists

# Example 1: Creating a List
# Creating a list of integers

numbers = [1, 2, 3, 4, 5]
print("Example 1: Creating a List")
print("List of numbers:", numbers)
print()

# Example 2: Accessing Elements
# Accessing elements in a list using index

print("Example 2: Accessing Elements")
print("First element:", numbers[0])
print("Last element:", numbers[-1])
print()

# Example 3: Slicing a List
# Slicing a list to get a subset of elements

print("Example 3: Slicing a List")
print("Slice from index 1 to 3:", numbers[1:4])  # [2, 3, 4]
print("Slice from index 2 to end:", numbers[2:])  # [3, 4, 5]
print("Slice from start to index 3:", numbers[:3])  # [1, 2, 3]
print()

# Example 4: Modifying Elements
# Modifying elements in a list

print("Example 4: Modifying Elements")
numbers[0] = 10
print("Updated list:", numbers)
print()

# Example 5: Adding Elements
# Adding elements to a list using append, insert, and extend methods

print("Example 5: Adding Elements")
numbers.append(6)  # Appends 6 to the end of the list
print("After append:", numbers)

numbers.insert(0, 0)  # Inserts 0 at index 0
print("After insert:", numbers)

numbers.extend([7, 8, 9])  # Extends the list by adding elements from another list
print("After extend:", numbers)
print()

# Example 6: Removing Elements
# Removing elements from a list using del, remove, and pop methods

print("Example 6: Removing Elements")
del numbers[-1]  # Deletes the last element
print("After del:", numbers)

numbers.remove(0)  # Removes the first occurrence of 0
print("After remove:", numbers)

popped_value = numbers.pop(4)  # Removes and returns element at index 4
print("Popped value:", popped_value)
print("After pop:", numbers)
print()

# Example 7: Finding Elements
# Finding elements in a list using index and in keyword

print("Example 7: Finding Elements")
index_of_3 = numbers.index(3)
print("Index of 3:", index_of_3)

is_present = 5 in numbers
print("Is 5 present in list?", is_present)
print()

# Example 8: List Operations
# List operations such as sorting, reversing, and counting elements

print("Example 8: List Operations")
numbers.reverse()  # Reverses the list
print("Reversed list:", numbers)

numbers.sort()  # Sorts the list in ascending order
print("Sorted list:", numbers)

count_of_3 = numbers.count(3)  # Counts occurrences of 3
print("Count of 3:", count_of_3)
print()

# Example 9: Nested Lists
# Creating and accessing elements in nested lists

print("Example 9: Nested Lists")
nested_list = [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
print("Nested list:", nested_list)
print("Element at row 1, column 2:", nested_list[1][2])
print()

# Example 10: List Comprehension
# Using list comprehension to create lists

print("Example 10: List Comprehension")
squares = [x ** 2 for x in range(1, 6)]
print("List of squares:", squares)
print()

# Example 11: Copying a List
# Copying a list using slice or copy method

print("Example 11: Copying a List")
numbers_copy = numbers[:]  # Creates a shallow copy using slice
print("Copied list:", numbers_copy)

numbers_copy.append(10)
print("Original list:", numbers)
print("Modified copy:", numbers_copy)
