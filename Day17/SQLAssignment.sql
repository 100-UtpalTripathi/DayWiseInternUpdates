  use pubs;
  -- 1) Print the storeid and number of orders for the store
		select stor_id, count(*) as "Number of orders"
		from sales
		group by stor_id

  -- 2) print the numebr of orders for every title
		select title_id, count(*) as "Number of orders"
		from sales
		group by title_id


  -- 3) print the publisher name and book name
		select p.pub_name, t.title
		from publishers p join titles t on p.pub_id = t.pub_id


  -- 4) Print the author full name for al the authors
		select concat(au_fname, ' ', au_lname) as "Full Name"
		from authors

  -- 5) Print the price for every book with tax (price+price*12.36/100)
		select title, (price + price*12.36/100) as "Price including Tax"
		from titles

  -- 6) Print the author name, title name
		select concat(a.au_fname, ' ', a.au_lname) as "Full Name", t.title 
		from titleauthor ta join titles t on ta.title_id = t.title_id 
		join authors a on a.au_id = ta.au_id

  -- 7) print the author name, title name and the publisher name
		select concat(a.au_fname, ' ', a.au_lname) as "Full Name", title, p.pub_name
		from titleauthor ta join titles t on ta.title_id = t.title_id 
		join authors a on a.au_id = ta.au_id
		join publishers p on p.pub_id = t.pub_id


  -- 8) Print the average price of books pulished by every publicher
		select p.pub_name, avg(price) as "Average Price per publisher"
		from publishers p left join titles t on p.pub_id = t.pub_id
		group by p.pub_name;


  -- 9) print the books published by 'Marjorie'
		select t.title
		from titleauthor ta join titles t on ta.title_id = t.title_id 
		join authors a on a.au_id = ta.au_id
		where a.au_fname = 'Marjorie';

  -- 10) Print the order numbers of books published by 'New Moon Books'
		select s.ord_num
		from publishers p join titles t on p.pub_id = t.pub_id
		join sales s on s.title_id = t.title_id
		where p.pub_name = 'New Moon Books';

  -- 11) Print the number of orders for every publisher
		select p.pub_name, count(*) as "Number of Orders"
		from publishers p left join titles t on p.pub_id = t.pub_id
		left join sales s on s.title_id = t.title_id
		group by p.pub_name;

  -- 12) print the order number , book name, quantity, price and the total price for all orders
		select s.ord_num, t.title, s.qty, t.price, (t.price*s.qty) as "Total Price"
		from sales s join titles t on s.title_id = t.title_id;

  -- 13) print he total order quantity fro every book
		select t.title, sum(qty) as "Total Order Quantity"
		from titles t inner join sales s on t.title_id = s.title_id
		group by t.title

  -- 14) print the total ordervalue for every book
		select t.title, sum(s.qty*t.price) as "Total Order Value"
		from titles t inner join sales s on t.title_id = s.title_id
		group by t.title

  -- 15) print the orders that are for the books published by the publisher for which 'Paolo' works for
		select s.ord_num, s.title_id, t.title, p.pub_name
		from sales s
		join titles t on s.title_id = t.title_id
		join publishers p on t.pub_id = p.pub_id
		join employee e on p.pub_id = e.pub_id
		where e.fname = 'Paolo';