document.getElementById("productForm").addEventListener("submit", function (e) {
  e.preventDefault();

  let valid = true;

  // Clear previous error messages
  document.getElementById("nameError").textContent = "";
  document.getElementById("categoryError").textContent = "";
  document.getElementById("priceError").textContent = "";
  document.getElementById("quantityError").textContent = "";

  // Get the form values
  const productName = document.getElementById("productName").value;
  const productCategory = document.getElementById("productCategory").value;
  const productPrice = document.getElementById("productPrice").value;
  const productQuantity = document.getElementById("productQuantity").value;

  // Validate form values
  if (!productName) {
    valid = false;
    document.getElementById("nameError").textContent =
      "Product name is required";
  }
  if (!productCategory) {
    valid = false;
    document.getElementById("categoryError").textContent =
      "Category is required";
  }
  if (!productPrice) {
    valid = false;
    document.getElementById("priceError").textContent = "Price is required";
  } 
  else if (productPrice <= 0) {
    valid = false;
    document.getElementById("priceError").textContent =
      "Price must be greater than 0";
  }
  if (!productQuantity) {
    valid = false;
    document.getElementById("quantityError").textContent =
      "Quantity is required";
  } 
  else if (productQuantity <= 0) {
    valid = false;
    document.getElementById("quantityError").textContent =
      "Quantity must be greater than 0";
  }

  if (!valid) {
    return;
  }

  // Generate auto product id for the product start from 1
  let productId = 1;
  const productRows = document.querySelectorAll("#productTable tbody tr");

  if (productRows.length) {
    const lastProductId =
      productRows[productRows.length - 1].querySelector("td").textContent;
    productId = parseInt(lastProductId) + 1;
  }

  // Create a new row for the table
  const newRow = document.createElement("tr");

  // Create cells for the new row
  const idCell = document.createElement("td");
  idCell.textContent = productId;
  newRow.appendChild(idCell);

  const nameCell = document.createElement("td");
  nameCell.textContent = productName;
  newRow.appendChild(nameCell);

  const categoryCell = document.createElement("td");
  categoryCell.textContent = productCategory;
  newRow.appendChild(categoryCell);

  const quantityCell = document.createElement("td");
  quantityCell.textContent = productQuantity;
  newRow.appendChild(quantityCell);

  const priceCell = document.createElement("td");
  priceCell.textContent = productPrice;
  newRow.appendChild(priceCell);

  // Append the new row to the table
  document.querySelector("#productTable tbody").appendChild(newRow);

  // Clear the form fields
  document.getElementById("productForm").reset();

  // Show toast message
  showToast();
});

function showToast() {
  const toast = document.getElementById("toast");
  toast.className = "toast show";
  setTimeout(function () {
    toast.className = toast.className.replace("show", "");
  }, 3000);

  var closeButton = document.querySelector(".toast .close");
  closeButton.onclick = function () {
    var toast = this.parentElement;
    toast.style.visibility = "hidden";
  };
}
