const url = "http://localhost:5255/api/Deposit";
const formElement = document.querySelector("form");

async function getData(data) {
    const response = await fetch(url, {
        method: "PUT",
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
    const amount = parseFloat(data.amount);

    if (!cardNumberRegex.test(data.cardNumber)) {
        alert("Card number must be 12 digits long.");
        return false;
    }

    if (!pinRegex.test(data.pin)) {
        alert("PIN must be 4 digits long.");
        return false;
    }

    if (isNaN(amount) || amount < 1 || amount > 100000) {
        alert("Amount must be between 1 and 100000.");
        return false;
    }

    return true;
}

function handleFormSubmission(event) {
    event.preventDefault();

    const formData = new FormData(formElement);
    console.log(formData.get("amount"));
    console.log(formData.get("cardno"));
    console.log(formData.get("pin"));
    const data = {
        amount: formData.get("amount"),
        cardNumber: formData.get("cardno"),
        pin: formData.get("pin")
    };

    if (validateForm(data)) {
        getData(data)
        .then(result => {
            alert("Your money has been deposited successfully. Your new balance is: " + result.currentBalance);
            window.location.href = "/index.html";
        })
        .catch(error => {
            alert("Error: " + error.message);
        });
    }
}

formElement.addEventListener("submit", handleFormSubmission);