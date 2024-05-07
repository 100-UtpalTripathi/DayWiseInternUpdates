-- 1) Create a stored procedure that will take the author firstname and print all the books polished by him with the publisher's name
		
		Create proc proc_GetBooksByAuthor(@FirstName varchar(25))
		as
		begin
			select t.title as BookTitle, p.pub_name as "Publisher's Name"
			from titles t
			join titleauthor ta on t.title_id = ta.title_id
			join authors a ON ta.au_id = a.au_id
			join publishers p ON p.pub_id = t.pub_id
			where a.au_fname = @FirstName;
		end;

		exec proc_GetBooksByAuthor Marjorie
		exec proc_GetBooksByAuthor Dean
		exec proc_GetBooksByAuthor Ann
		exec proc_GetBooksByAuthor Burt
	

-- 2) Create a sp that will take the employee's firstname and print all the titles sold by him/her, price, quantity and the cost.

		Create proc proc_GetTitlesSoldByEmployee(@EmployeeFirstName VARCHAR(25))
		as
		begin
			select t.title as 'Title Name', t.price, s.qty as 'Quantity', (t.price * s.qty) as 'Cost'
			from employee e
			join Titles t on t.pub_id = e.pub_id
			join sales s on t.title_id = s.title_id
			where e.fname = @EmployeeFirstName;
		end;


		exec proc_GetTitlesSoldByEmployee Paolo
		exec proc_GetTitlesSoldByEmployee Victoria

-- 3) Create a query that will print all names from authors and employees
		
		select au_fname, au_lname from authors
		UNION
		SELECT fname, lname from employee;



-- 4) Create a  query that will fetch the data from sales,titles, publisher and authors table to print title name, 
      --Publisher's name, author's full name with quantity ordered and price for the order for all orders,
		--print first 5 orders after sorting them based on the price of order


		select top 5 t.title AS BookTitle, p.pub_name, CONCAT(a.au_fname, ' ', a.au_lname) AS AuthorName, s.qty as "Quantity Ordered", 
		t.Price * s.qty AS OrderTotalPrice

		from
			sales s
		join 
			titles t ON s.title_id = t.title_id
		join 
			publishers p ON t.pub_id = p.pub_id
		join
		   titleauthor ta on t.title_id = ta.title_id
		join
			authors a ON ta.au_id = a.au_id
		ORDER BY 
			t.price;