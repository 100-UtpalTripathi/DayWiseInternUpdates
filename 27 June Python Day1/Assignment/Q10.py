# Question 10: Print a pyramid of stars for the number of rows specified
rows = int(input("Enter the number of rows for the pyramid: "))

for i in range(1, rows + 1):  # Loop through the number of rows
    # Print leading spaces
    print(" " * (rows - i), end="")
    
    # Print stars
    print("*" * (2 * i - 1))
1