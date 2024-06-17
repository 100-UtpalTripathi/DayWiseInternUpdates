

var clickButton = () => {
  fetch("https://dummyjson.com/products", {
    method: "GET",
  })
    .then(async (response) => {
      var data = await response.json();
      var divProducts = document.getElementById("divProducts");
      var productData = "";

      data.products.forEach((element) => {
        var discountedPrice = element.price - (element.price * element.discountPercentage / 100);

        productData += `
          <div class="col-lg-4 col-md-6 col-sm-12 mb-4">
            <div class="card h-100">
              <img src="${element.thumbnail}" class="card-img-top" alt="${element.title}">
              <div class="card-body">
                <h5 class="card-title">${element.title}</h5>
                <p class="card-text">${element.description}</p>
                <p class="card-text">
                  <span class="price-old">$${element.price}</span>
                  <span class="price-new">$${discountedPrice.toFixed(2)}</span>
                </p>
                <p class="card-text"><strong>Discount:</strong> ${element.discountPercentage}%</p>
                <p class="card-text"><strong>Rating:</strong> ${element.rating}</p>
                <p class="card-text"><strong>Category:</strong> ${element.category}</p>
                <button class="btn btn-success add-to-cart">Add to Cart</button>
              </div>
            </div>
          </div>
        `;
      });

      divProducts.innerHTML = productData;
    })
    .catch((error) => {
      console.error(error);
    });
};


document.addEventListener('DOMContentLoaded', clickButton);