# ATM Application

## Video Explanation

A video showcasing of the project is available [here](https://drive.google.com/file/d/1yvr25D5QNCSlHaCJwQZ5KSrEKtQ7fMcI/view?usp=sharing).

## Overview

This project is a simple ATM application that provides functionalities such as checking balance, withdrawing, and depositing money. The application has been developed using HTML, CSS, JavaScript and NodeJS for the frontend and C# with .NET for the backend.

## Table of Contents

- [Team Members](#team-members)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [Installation](#installation)
- [Usage](#usage)

## Team Members

- **Huzair** - Backend Development
- **Aslam** - Backend Development
- **Sakthi** - Frontend Development
- **Avish** - Backend and Frontend Integration
- **Utpal** - Video showcasing and Short Documentation(ReadME.md)

## Features

- **Check Balance**: View the current balance of your account.
- **Withdraw Money**: Withdraw a specified amount from your account.
- **Deposit Money**: Deposit a specified amount into your account.

## Technologies Used

- **Frontend**: HTML, CSS, JavaScript, NodeJS
- **Backend**: C#, .NET, Entity Framework Core

## Installation

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download)
- [Node.js](https://nodejs.org/) (for frontend development)

### Steps

1. **Clone the repository**

    ```sh
    git clone https://github.com/your-repo/atm-application.git
    cd atm-application
    ```

2. **Backend Setup**

    - Navigate to the backend project directory

        ```sh
        cd backend
        ```

    - Apply Entity Framework Core migrations

        ```sh
        dotnet ef database update
        ```

3. **Frontend Setup**

    - Navigate to the frontend project directory

        ```sh
        cd frontend
        ```

    - Install dependencies

        ```sh
        npm install
        ```

    - Start the development server

        ```sh
        npm start
        ```

## Usage

1. Open your web browser and navigate to `http://localhost:3000` to access the frontend interface.
2. Use the provided options to check your balance, withdraw money, or deposit money.

