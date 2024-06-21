// Person class with name and age properties
class Person {
    constructor(name, age) {
        this.name = name;
        this.age = age;
    }

    // Encapsulation: using getter and setter methods
    getName() {
        return this.name;
    }

    setName(name) {
        this.name = name;
    }

    getAge() {
        return this.age;
    }

    setAge(age) {
        this.age = age;
    }

    // Abstraction: Will be exposing this method to the outside world
    describe() {
        return `${this.name} is ${this.age} years old.`;
    }
}

// Inheritance: Student class extends Person class
class Student extends Person {

    // Constructor with name, age, studentId, and major properties
    constructor(name, age, studentId, major) {
        super(name, age);  //Inheritance: using super() to call the parent class constructor
        this.studentId = studentId;  
        this.major = major;
    }

    // Encapsulation: using getter and setter methods for new properties
    getStudentId() {
        return this.studentId;
    }

    setStudentId(studentId) {
        this.studentId = studentId;
    }

    getMajor() {
        return this.major;
    }

    setMajor(major) {
        this.major = major;
    }

    // Polymorphism, Method overriding: overriding the describe method of the parent class
    describe() {
        return `${this.name} is ${this.age} years old, student ID is ${this.studentId}, and major is ${this.major}.`;
    }
}

// Creating an instance of the Student class
let student = new Student("Emily Harrison", 23, "S12345", "Computer Science");

console.log("------------------------------------------------------------------------------")

// Accessing properties and methods
console.log(student.describe()); 
console.log("------------------------------------------------------------------------------")

student.setAge(21);
console.log(student.getAge());   
student.setMajor("Information Technology");
console.log(student.getMajor()); 

console.log("------------------------------------------------------------------------------")

console.log(student.describe()); 


console.log("------------------------------------------------------------------------------")

