# Define a class named 'Car'
class Car:
    # Class attribute: common to all instances of the class
    wheels = 4

    # The initializer method (constructor) to initialize an instance of the class
    def __init__(self, make, model, year):
        # Instance attributes: unique to each instance of the class
        self.make = make
        self.model = model
        self.year = year
        self.odometer_reading = 0  # Initialize odometer reading to 0

    # Method to describe the car
    def describe_car(self):
        description = f"{self.year} {self.make} {self.model}"
        return description

    # Method to read the odometer
    def read_odometer(self):
        print(f"This car has {self.odometer_reading} miles on it.")

    # Method to update the odometer
    def update_odometer(self, mileage):
        # Ensure that the mileage cannot be rolled back
        if mileage >= self.odometer_reading:
            self.odometer_reading = mileage
        else:
            print("You can't roll back an odometer!")

    # Method to increment the odometer
    def increment_odometer(self, miles):
        if miles >= 0:
            self.odometer_reading += miles
        else:
            print("You can't add negative miles!")

# Create an instance of the Car class
my_car = Car('Toyota', 'Corolla', 2020)

# Use the describe_car method to print the description of the car
print(my_car.describe_car())

# Read the initial odometer reading
my_car.read_odometer()

# Update the odometer reading
my_car.update_odometer(150)

# Read the updated odometer reading
my_car.read_odometer()

# Increment the odometer reading
my_car.increment_odometer(50)

# Read the incremented odometer reading
my_car.read_odometer()

# Attempt to roll back the odometer (should print an error message)
my_car.update_odometer(100)

# Attempt to increment with negative miles (should print an error message)
my_car.increment_odometer(-20)
