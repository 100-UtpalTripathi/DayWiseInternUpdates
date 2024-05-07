-- 1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name

	

-- 2) Create a sp that will take the employee's firtname and print all the titles sold by him/her, price, quantity and the cost.



-- 3) Create a query that will print all names from authors and employees



-- 4) Create a  query that will fetch the data from sales,titles, publisher and authors table to print title name, 
      --Publisher's name, author's full name with quantity ordered and price for the order for all orders,
		--print first 5 orders after sorting them based on the price of order


		SELECT TOP 5 t.title AS BookTitle, p.pub_name, CONCAT(a.au_fname, ' ', a.au_lname) AS AuthorName, s.quantity, 
		s.Price * s.Quantity AS OrderPrice

		FROM 
			sales s
		JOIN 
			titles t ON s.title_id = t.title_id
		JOIN 
			publishers p ON t.pub_id = p.pub_id
		JOIN
		
			authors a ON t. = a.au_id
		ORDER BY 
			s.Price;