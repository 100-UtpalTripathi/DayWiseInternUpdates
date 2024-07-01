import datetime

# Employee class
class Employee:

    # Constructor to initialize Employee object
    def __init__(self, name, dob, phone, email):
        self.name = name
        self.dob = dob
        self.phone = phone
        self.email = email
    
    # Method to calculate age based on DOB
    def calculate_age(self):
        today = datetime.date.today()
        dob_date = datetime.datetime.strptime(self.dob, '%Y-%m-%d').date()
        age = today.year - dob_date.year - ((today.month, today.day) < (dob_date.month, dob_date.day))
        return age
    
    # String representation of Employee object
    def __str__(self):
        return f"Name: {self.name}\nDOB: {self.dob}\nPhone: {self.phone}\nEmail: {self.email}\nAge: {self.calculate_age()}"
