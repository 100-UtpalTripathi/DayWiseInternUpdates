const url = "http://localhost:5255/balance";
const formElement = document.querySelector("form");

async function getData(data) {
    const response = await fetch(url, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(data)
    });

    if (!response.ok) { // Check if response status is not OK (i.e., >= 400)
        const errorData = await response.json();
        if (response.status >= 400 && response.status < 500) {
            throw new Error(errorData.message || "Client-side error occurred.");
        }
        if (response.status >= 500) {
            throw new Error("The server cannot process the request right now.");
        }
    }

    return response.json();
}

function validateForm(data) {
    const cardNumberRegex = /^\d{12}$/;
    const pinRegex = /^\d{4}$/;

    if (!cardNumberRegex.test(data.cardNumber)) {
        alert("Card number must be 12 digits long.");
        return false;
    }

    if (!pinRegex.test(data.pin)) {
        alert("PIN must be 4 digits long.");
        return false;
    }

    return true;
}

function handleFormSubmission(event) {
    event.preventDefault();

    const formData = new FormData(formElement);
    const data = {
        cardNumber: formData.get("cardno"),
        pin: formData.get("pin")
    };

    if (validateForm(data)) {
        getData(data)
        .then(result => {
            alert("Your current balance is: $" + result.balance);
            window.location.href = "/index.html";
        })
        .catch(error => {
            alert("Error: " + error.message);
        });
    }
}

formElement.addEventListener("submit", handleFormSubmission);