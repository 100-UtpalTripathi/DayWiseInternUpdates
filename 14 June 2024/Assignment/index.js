const professionArray = [
  "Civil Engineer",
  "Doctor",
  "Artist",
  "Teacher",
  "Software Engineer",
  "Developer",
  "Designer",
  "Architect",
  "Photographer",
  "Lawyer",
  "Accountant",
  "Chef",
];

const professionDatalist = document.getElementById("professions");
const professionInput = document.getElementById("profession");

// function to load professions in the datalist
function loadProfessions() {
  professionDatalist.innerHTML = "";
  professionArray.forEach((profession) => {
    let option = document.createElement("option");
    option.value = profession;
    professionDatalist.appendChild(option);
  });
}

// function to calculate age from date of birth
function calculateAge(dob) {
  const diff = new Date() - new Date(dob);
  return Math.floor(diff / 31557600000); // 1000 * 60 * 60 * 24 * 365.25
}

// event listener for date of birth input
document.getElementById("dob").addEventListener("change", function () {
  const dob = this.value;
  if (dob) {
    const age = calculateAge(dob);
    document.getElementById("age").value = age;
  }
});

// validation functions
var validateName = () => {
  const name = document.getElementById("name");
  const nameError = document.getElementById("nameError");
  const regex = /^[a-zA-Z\s]+$/;
  if (name.value.trim() === "") {
    name.classList.add("error");
    name.classList.remove("correct");
    nameError.textContent = "Name is required.";
  } else if (!regex.test(name.value)) {
    name.classList.add("error");
    name.classList.remove("correct");
    nameError.textContent = "Name must contain only letters and spaces.";
  } else {
    name.classList.remove("error");
    name.classList.add("correct");
    nameError.textContent = "";
  }
};

function validatePhone() {
  const phone = document.getElementById("phone");
  const phoneError = document.getElementById("phoneError");
  const regex = /^\d{10}$/;
  if (phone.value.trim() === "") {
    phone.classList.add("error");
    phone.classList.remove("correct");
    phoneError.textContent = "Phone number is required.";
  } else if (!regex.test(phone.value)) {
    phone.classList.add("error");
    phone.classList.remove("correct");
    phoneError.textContent = "Phone number must be 10 digits.";
  } else {
    phone.classList.remove("error");
    phone.classList.add("correct");
    phoneError.textContent = "";
  }
}

function validateDOB() {
  const dob = document.getElementById("dob");
  const dobError = document.getElementById("dobError");
  const today = new Date().toISOString().split("T")[0];
  if (dob.value === "") {
    dob.classList.add("error");
    dob.classList.remove("correct");
    dobError.textContent = "Date of birth is required.";
  } else if (dob.value > today) {
    dob.classList.add("error");
    dob.classList.remove("correct");
    dobError.textContent = "Date of birth cannot be in the future.";
  } else {
    dob.classList.remove("error");
    dob.classList.add("correct");
    dobError.textContent = "";
  }
}

function validateEmail() {
  const email = document.getElementById("email");
  const emailError = document.getElementById("emailError");
  const regex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;
  if (email.value.trim() === "") {
    email.classList.add("error");
    email.classList.remove("correct");
    emailError.textContent = "Email is required.";
  } else if (!regex.test(email.value)) {
    email.classList.add("error");
    email.classList.remove("correct");
    emailError.textContent = "Email is not valid.";
  } else {
    email.classList.remove("error");
    email.classList.add("correct");
    emailError.textContent = "";
  }
}

function validateProfession() {
  const profession = document.getElementById("profession");
  const professionError = document.getElementById("professionError");
  if (profession.value.trim() === "") {
    profession.classList.add("error");
    profession.classList.remove("correct");
    professionError.textContent = "Profession is required.";
  } else {
    profession.classList.remove("error");
    profession.classList.add("correct");
    professionError.textContent = "";
  }
}

// form submit event listener
document
  .getElementById("registrationForm")
  .addEventListener("submit", function (e) {
    e.preventDefault();
    let valid = true;
    let consolidatedError = "";

    // validate all fields
    validateName();
    validatePhone();
    validateDOB();
    validateEmail();
    validateProfession();

    // check if gender is selected
    if (!document.querySelector('input[name="gender"]:checked')) {
      valid = false;
      document.getElementById("genderError").textContent =
        "Please select a gender.";
      consolidatedError += "Please select a gender.<br />";
    } else {
      document.getElementById("genderError").textContent = "";
    }

    // check if at least one qualification is selected
    if (!document.querySelector('input[type="checkbox"]:checked')) {
      valid = false;
      document.getElementById("qualificationError").textContent =
        "Please select at least one qualification.";
      consolidatedError += "Please select at least one qualification.<br />";
    } else {
      document.getElementById("qualificationError").textContent = "";
    }

    // check if any input field has the error class
    if (document.querySelector(".error")) {
      valid = false;
      consolidatedError += "Please correct the errors in the form.<br />";
    }

    if (valid) {
      const newProfession = professionInput.value;
      // add new profession to the list if it is not already present
      if (!professionArray.includes(newProfession)) {
        professionArray.push(newProfession);
        loadProfessions();
      }
      alert("Form submitted successfully!");
      this.reset();
    } else {
      document.getElementById("consolidatedError").innerHTML =
        consolidatedError;
    }
  });

loadProfessions();

// Set the max value for the date of birth input to today
const dobInput = document.getElementById("dob");
const today = new Date().toISOString().split("T")[0];
dobInput.setAttribute("max", today);
