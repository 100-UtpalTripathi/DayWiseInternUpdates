// script.js

// Define a local array of user credentials
const users = [
    { username: 'u1', password: 'p1' },
    { username: 'u2', password: 'p2' },
    { username: 'u3', password: 'p3' }
];



// Function to validate username and password against local array
function validateCredentials(username, password) {
    // Check if there's a user in the array with matching credentials
    return users.some(user => user.username === username && user.password === password);
}

// Function to handle form submission
function handleFormSubmit(event) {
    event.preventDefault(); // Prevent the default form submission
    
    // Get form input values
    const username = document.getElementById('username').value;
    const password = document.getElementById('password').value;
    
    // Validate username and password
    const isValid = validateCredentials(username, password);

    // Display login message based on validation result
    const loginMessage = document.getElementById('loginMessage');
    if (isValid) {
        loginMessage.textContent = 'Login successful!';
        loginMessage.style.color = 'green';
    } else {
        loginMessage.textContent = 'Invalid username or password. Please try again.';
        loginMessage.style.color = 'red';
    }
}



// Event listener for form submission
document.getElementById('loginForm').addEventListener('submit', handleFormSubmit);
