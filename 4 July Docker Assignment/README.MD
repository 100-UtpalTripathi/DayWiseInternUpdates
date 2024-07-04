# PostgreSQL with Docker - Step-by-Step Guide

This guide explains how to set up a PostgreSQL database in a Docker container, create a database and tables, insert data, and run queries.

## Prerequisites

- Docker installed on your machine.

## Pull the PostgreSQL Image

1. Open your terminal and pull the latest PostgreSQL image from Docker Hub:

    ```sh
    docker pull postgres:latest
    ```

## Run the PostgreSQL Container

2. Run the PostgreSQL container:

    ```sh
    docker run --name postgres-container -e POSTGRES_HOST_AUTH_METHOD=trust -d postgres
    ```

    - `--name postgres-container`: Names the container `postgres-container`.
    - `-e POSTGRES_HOST_AUTH_METHOD=trust`: Sets the authentication method to `trust` (no password required).
    - `-d`: Runs the container in detached mode.

## Verify the Container is Running

3. Check the running containers:

    ```sh
    docker ps
    ```

    You should see the `postgres-container` running.

## Access the PostgreSQL Shell

4. Access the PostgreSQL shell inside the running container:

    ```sh
    docker exec -it postgres-container psql -U postgres
    ```

## Create the Database

5. Create the database `dbDocker`:

    ```sql
    CREATE DATABASE dbDocker;
    ```

## Connect to the New Database

6. Exit the PostgreSQL shell and reconnect to the `dbDocker` database:

    ```sh
    \q
    docker exec -it postgres-container psql -U postgres -d dbDocker
    ```

## Create Tables

7. Create the `Department`, `Employee`, and `Salary` tables:

    ```sql
    -- Create Department Table
    CREATE TABLE Department (
        id SERIAL PRIMARY KEY,
        name VARCHAR(100) NOT NULL
    );

    -- Create Employee Table
    CREATE TABLE Employee (
        id SERIAL PRIMARY KEY,
        name VARCHAR(100) NOT NULL,
        age INT,
        phone VARCHAR(15),
        department_id INT,
        FOREIGN KEY (department_id) REFERENCES Department(id)
    );

    -- Create Salary Table
    CREATE TABLE Salary (
        employee_id INT,
        amount DECIMAL(10, 2),
        FOREIGN KEY (employee_id) REFERENCES Employee(id)
    );
    ```

## Insert Data into Tables

8. Insert data into the tables:

    ```sql
    -- Insert Data into Department Table
    INSERT INTO Department (name) VALUES ('HR'), ('Finance'), ('Engineering');

    -- Insert Data into Employee Table
    INSERT INTO Employee (name, age, phone, department_id) VALUES 
    ('John Doe', 30, '555-1234', 1),
    ('Jane Smith', 25, '555-5678', 2),
    ('Bob Johnson', 35, '555-8765', 3);

    -- Insert Data into Salary Table
    INSERT INTO Salary (employee_id, amount) VALUES 
    (1, 60000),
    (2, 70000),
    (3, 80000);
    ```

## Query Data

9. Run a SELECT query to retrieve employee information along with their department and salary:

    ```sql
    SELECT e.name AS employee_name, e.age, e.phone, d.name AS department_name, s.amount AS salary
    FROM Employee e
    JOIN Department d ON e.department_id = d.id
    JOIN Salary s ON e.id = s.employee_id;
    ```

## Stop and Start the Container

10. Stop the running PostgreSQL container:

    ```sh
    docker stop postgres-container
    ```

11. Start the PostgreSQL container again:

    ```sh
    docker start postgres-container
    ```

## Reconnect to the Database

12. Reconnect to the `dbDocker` database to verify data persists:

    ```sh
    docker exec -it postgres-container psql -U postgres -d dbDocker
    ```

## Verify Data Persistence

13. Run the SELECT query again to ensure the data is still there:

    ```sql
    SELECT e.name AS employee_name, e.age, e.phone, d.name AS department_name, s.amount AS salary
    FROM Employee e
    JOIN Department d ON e.department_id = d.id
    JOIN Salary s ON e.id = s.employee_id;
    ```

## Summary

This guide covers the following steps:
- Pulling the PostgreSQL Docker image.
- Running the PostgreSQL container.
- Creating a database and tables.
- Inserting data into tables.
- Running queries to retrieve data.
- Stopping and starting the container.
- Verifying data persistence.

These steps provide a comprehensive walkthrough for setting up and using PostgreSQL in a Docker container. For more details and advanced configurations, refer to the [official PostgreSQL Docker image documentation](https://hub.docker.com/_/postgres).
