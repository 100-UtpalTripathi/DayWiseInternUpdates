# Define a base class named 'Car'
class Car:
    def __init__(self, make, model, year):
        self.make = make
        self.model = model
        self.year = year

    def describe_vehicle(self):
        return f"{self.year} {self.make} {self.model}"

# Define a derived class named 'ElectricCar' that inherits from 'Car'
class ElectricCar(Car):
    def __init__(self, make, model, year, battery_size=75):
        super().__init__(make, model, year)
        self.battery_size = battery_size

    def describe_vehicle(self):
        return f"{self.year} {self.make} {self.model} with a {self.battery_size}-kWh battery"

# Define another derived class named 'Truck' that inherits from 'Car'
class Truck(Car):
    def __init__(self, make, model, year, towing_capacity):
        super().__init__(make, model, year)
        self.towing_capacity = towing_capacity

    def describe_vehicle(self):
        return f"{self.year} {self.make} {self.model} with a towing capacity of {self.towing_capacity} lbs"

# Define a function that describes a vehicle, demonstrating polymorphism
def describe_vehicle(vehicle):
    print(vehicle.describe_vehicle())

# Create instances of each class
my_car = Car('Toyota', 'Corolla', 2020)
my_electric_car = ElectricCar('Tesla', 'Model S', 2021)
my_truck = Truck('Ford', 'F-150', 2019, 13000)

# Use the describe_vehicle function with different types of vehicles
describe_vehicle(my_car)          # Output: 2020 Toyota Corolla
describe_vehicle(my_electric_car) # Output: 2021 Tesla Model S with a 75-kWh battery
describe_vehicle(my_truck)        # Output: 2019 Ford F-150 with a towing capacity of 13000 lbs
