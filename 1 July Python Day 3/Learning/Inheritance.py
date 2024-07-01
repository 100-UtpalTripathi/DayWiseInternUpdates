# Define a base class named 'Car'
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

# Define a derived class named 'ElectricCar' that inherits from 'Car'
class ElectricCar(Car):
    # The initializer method for the derived class
    def __init__(self, make, model, year, battery_size=75):
        # Initialize attributes of the parent class
        super().__init__(make, model, year)
        # Initialize attribute specific to ElectricCar
        self.battery_size = battery_size

    # Method to describe the battery
    def describe_battery(self):
        print(f"This car has a {self.battery_size}-kWh battery.")

    # Overriding the describe_car method to include battery size
    def describe_car(self):
        description = f"{self.year} {self.make} {self.model} with a {self.battery_size}-kWh battery"
        return description

# Create an instance of the Car class
my_car = Car('Toyota', 'Corolla', 2020)

# Create an instance of the ElectricCar class
my_electric_car = ElectricCar('Tesla', 'Model S', 2021)

# Use the describe_car method from Car class
print(my_car.describe_car())

# Use the describe_car method from ElectricCar class (overridden)
print(my_electric_car.describe_car())

# Use the describe_battery method specific to ElectricCar class
my_electric_car.describe_battery()

# Read the initial odometer reading for both cars
my_car.read_odometer()
my_electric_car.read_odometer()

# Update the odometer reading for both cars
my_car.update_odometer(150)
my_electric_car.update_odometer(200)

# Read the updated odometer readings
my_car.read_odometer()
my_electric_car.read_odometer()
