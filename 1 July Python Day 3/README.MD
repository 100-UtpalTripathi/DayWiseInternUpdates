# Python Learning Documentation

This repository contains documentation and explanations of various Python topics learned, including classes, inheritance, polymorphism, modules, exception handling, and file handling.

## Table of Contents

- [Python Classes](#python-classes)
- [Inheritance](#inheritance)
- [Polymorphism](#polymorphism)
- [Modules](#modules)
- [Exception Handling](#exception-handling)
- [File Handling](#file-handling)

## Python Classes

Python classes provide a way to bundle data and functionality together. Creating a new class creates a new type of object, allowing new instances of that type to be made. A class defines the attributes and methods that its objects will have.

### Key Concepts:
- **Class**: A blueprint for creating objects (a particular data structure).
- **Object**: An instance of a class.
- **Attributes**: Variables that belong to an object or class.
- **Methods**: Functions that belong to an object or class.

## Inheritance

Inheritance allows one class to inherit the attributes and methods of another class. This helps in reusing code and creating a hierarchical structure of classes.

### Key Concepts:
- **Parent Class (Base Class)**: The class whose attributes and methods are inherited.
- **Child Class (Derived Class)**: The class that inherits from the parent class.
- **Method Overriding**: Redefining a method in the child class that is already defined in the parent class.

## Polymorphism

Polymorphism allows methods to do different things based on the object it is acting upon. It provides a way to perform a single action in different forms.

### Key Concepts:
- **Polymorphic Function**: A function that can take objects of different classes and can perform different operations based on the class of the object.
- **Method Overriding**: A child class provides a specific implementation of a method that is already defined in its parent class.

## Modules

Modules in Python are files containing Python code that can include functions, classes, and variables. Grouping related code into a module makes the code easier to understand and use. Modules help in organizing and managing large codebases.

### Key Concepts:
- **Importing Modules**: Using the `import` statement to bring a module into another script.
- **Standard Modules**: Built-in modules provided by Python.
- **Custom Modules**: User-defined modules created for specific tasks.

## Exception Handling

Exception handling in Python involves responding to runtime errors in a controlled way. It uses `try`, `except`, `else`, and `finally` blocks to handle exceptions.

### Key Concepts:
- **try**: Block of code to be executed that may raise an exception.
- **except**: Block of code to be executed if an error occurs in the try block.
- **else**: Block of code to be executed if no error occurs.
- **finally**: Block of code that will be executed regardless of whether an error occurred or not.
- **Raising Exceptions**: Manually raising an exception using the `raise` statement.
- **Custom Exceptions**: Creating user-defined exceptions by inheriting from the `Exception` class.

## File Handling

File handling in Python allows you to read from and write to files. It uses functions like `open()`, `read()`, `write()`, and `close()` to perform file operations.

### Key Concepts:
- **Opening Files**: Using the `open()` function with various modes (read, write, append, etc.).
- **Reading Files**: Using methods like `read()`, `readline()`, and `readlines()` to read file content.
- **Writing Files**: Using the `write()` and `writelines()` methods to write content to a file.
- **Appending Files**: Adding content to the end of a file without deleting existing content.
- **Using with Statement**: Managing file context to ensure proper resource handling and automatic closing of files.
- **File Paths**: Understanding absolute and relative file paths for accessing files.
