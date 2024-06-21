
// Defining a prototype object
const personPrototype = {
    greet: function() {
        console.log(`Hello, my name is ${this.name}`);
    }
};

// Create an object that inherits from personPrototype
const john = Object.create(personPrototype);

// Add properties to the object
john.name = 'John';

// Call the greet method
john.greet();


// Create another object that inherits from personPrototype
const jane = Object.create(personPrototype);
jane.name = 'Harriet';
jane.greet(); 
