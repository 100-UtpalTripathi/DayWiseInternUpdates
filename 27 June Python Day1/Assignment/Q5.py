# 5. Add validation for entered name, age, date of birth, and phone number and print details in proper format
import re
from datetime import datetime

def validate_date(date):
    try:
        datetime.strptime(date, '%Y-%m-%d')
        return True
    except ValueError:
        return False

def validate_phone(phone):
    return re.match(r'^\d{10}$', phone)

name = input("Enter your name: ")

while True:
    age = input("Enter your age: ")
    if not age.isdigit():
        print("Invalid age. Please enter a valid number.")
        continue
    break

while True:
    dob = input("Enter your date of birth (YYYY-MM-DD): ")
    if not validate_date(dob):
        print("Invalid date format. Please enter date in YYYY-MM-DD format.")
        continue
    break

while True:
    phone = input("Enter your phone number: ")
    if not validate_phone(phone):
        print("Invalid phone number. Please enter 10 digits.")
        continue
    break

print("\nPersonal Details:")
print(f"Name: {name}")
print(f"Age: {age}")
print(f"Date of Birth: {dob}")
print(f"Phone Number: {phone}")
