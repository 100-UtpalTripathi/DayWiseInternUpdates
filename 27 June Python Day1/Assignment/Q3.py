# 3. Take name and gender and print a greeting with salutation
name = input("Enter your name: ")
gender = input("Enter your gender (Male/Female): ").lower()

if gender == "male":
    print(f"Hello, Mr. {name}!")
elif gender == "female":
    print(f"Hello, Ms. {name}!")
else:
    print(f"Hello, {name}!")
