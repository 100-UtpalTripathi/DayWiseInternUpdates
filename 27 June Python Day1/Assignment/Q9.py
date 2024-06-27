# Question 9: Find All Permutations of a given string
from itertools import permutations

input_string = input("Enter a string: ")
perms = [''.join(p) for p in permutations(input_string)]
print("Permutations:")

for perm in perms:
    print(perm)
