# Example: Python Operators and Conditional Operators

# Arithmetic Operators
a = 10
b = 3
print("Arithmetic Operators:")
print("Addition:", a + b)
print("Subtraction:", a - b)
print("Multiplication:", a * b)
print("Division:", a / b)
print("Integer Division:", a // b)
print("Modulus:", a % b)
print("Exponentiation:", a ** b)
print()

# Comparison Operators
x = 5
y = 10
print("Comparison Operators:")
print("Equal to:", x == y)
print("Not equal to:", x != y)
print("Greater than:", x > y)
print("Less than:", x < y)
print("Greater than or equal to:", x >= y)
print("Less than or equal to:", x <= y)
print()

# Logical Operators
p = True
q = False
print("Logical Operators:")
print("AND:", p and q)
print("OR:", p or q)
print("NOT:", not p)
print()

# Assignment Operators
a = 10
print("Assignment Operators:")
a += 5  # Equivalent to a = a + 5
print("Add and Assign:", a)
a -= 3  # Equivalent to a = a - 3
print("Subtract and Assign:", a)
a *= 2  # Equivalent to a = a * 2
print("Multiply and Assign:", a)
a /= 4  # Equivalent to a = a / 4
print("Divide and Assign:", a)
print()

# Identity Operators
list1 = [1, 2, 3]
list2 = [1, 2, 3]
list3 = list1
print("Identity Operators:")
print("is (same object):", list1 is list3)
print("is not (different object):", list1 is not list2)
print()

# Membership Operators
fruits = ["apple", "banana", "cherry"]
print("Membership Operators:")
print("in:", "banana" in fruits)
print("not in:", "orange" not in fruits)
print()

# Conditional Operator (Ternary Operator)
age = 20
status = "Adult" if age >= 18 else "Minor"
print("Conditional Operator:")
print("Status:", status)
print()



