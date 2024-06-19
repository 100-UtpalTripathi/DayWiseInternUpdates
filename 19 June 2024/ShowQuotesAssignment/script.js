// Function to show Home content
function showHome() {
  document.getElementById("content").innerHTML = `
        <div class="text-center mt-5">
            <h1>Welcome to the Quotes Project</h1>
            <p class="lead">This project showcases a collection of inspiring quotes. Navigate to the Quotes page to explore.</p>
        </div>
    `;
}


// Function to show Quotes content with pagination and search
function showQuotes() {
    document.getElementById("content").innerHTML = `
          <div class="mt-3">
              <div class="input-group mb-3">
                  <input type="text" id="search-input" class="form-control" placeholder="Search by author" aria-label="Search by author" aria-describedby="search-button">
                  <button class="btn btn-outline-secondary" type="button" id="search-button">Search</button>
              </div>
              <div id="quotes-container" class="row"></div>
              <nav>
                  <ul class="pagination justify-content-center mt-4" id="pagination"></ul>
              </nav>
          </div>
      `;
    fetchQuotes();
  }
  

  const apiUrl = "https://dummyjson.com/quotes";
  let quotes = [];
  let filteredQuotes = [];
  let currentPage = 1;
  const quotesPerPage = 5;
  
  async function fetchQuotes() {
    try {
      const response = await fetch(apiUrl);
      if (!response.ok) {
        throw new Error("Failed to fetch quotes!");
      }
      const data = await response.json();
  
      quotes = data.quotes;
      filteredQuotes = quotes;
  
      displayQuotes();
      setupPagination();
  
    } catch (error) {
      console.error("Error fetching quotes:", error);
    }
  }
  
  function displayQuotes() {
    const quotesContainer = document.getElementById("quotes-container");
    quotesContainer.innerHTML = "";
  
    const start = (currentPage - 1) * quotesPerPage;
    const end = start + quotesPerPage;
    const paginatedQuotes = filteredQuotes.slice(start, end);
  
    paginatedQuotes.forEach((quote) => {
      const quoteCard = document.createElement("div");
      quoteCard.classList.add("quote-card", "col-md-4");
  
      quoteCard.innerHTML = `
              <blockquote class="blockquote">
                  <p>${quote.quote}</p>
                  <footer class="blockquote-footer">${quote.author}</footer>
              </blockquote>
          `;
  
      quotesContainer.appendChild(quoteCard);
    });
  }
  
  function setupPagination() {
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = "";
  
    const pageCount = Math.ceil(filteredQuotes.length / quotesPerPage);
  
    for (let i = 1; i <= pageCount; i++) {
      const pageItem = document.createElement("li");
      pageItem.classList.add("page-item");
      if (i === currentPage) pageItem.classList.add("active");
  
      const pageLink = document.createElement("a");
      pageLink.classList.add("page-link");
      pageLink.href = "#";
      pageLink.innerText = i;
  
      pageLink.addEventListener("click", (e) => {
        e.preventDefault();
  
        currentPage = i;
        displayQuotes();
        setupPagination();
      });
  
      pageItem.appendChild(pageLink);
      pagination.appendChild(pageItem);
    }
  }
  
  // Function to filter quotes by author
  function filterQuotes() {
    const searchInput = document.getElementById("search-input").value.toLowerCase();

    // Filter quotes by author
    filteredQuotes = quotes.filter(quote => quote.author.toLowerCase().includes(searchInput));
    currentPage = 1; // Reset to the first page
    displayQuotes();
    setupPagination();
  }
  
  // Load the Home content by default
  document.addEventListener("DOMContentLoaded", () => {
    showHome();
  });
  
  // Event listener for the Quotes link
  document.addEventListener("click", (event) => {
    if (event.target && event.target.id === 'search-button') {
      filterQuotes();
    }
  });
  