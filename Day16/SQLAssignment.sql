
 select * from titles;

 -- 1) Print all the titles names
		select DISTINCT(title) 
		from titles;


-- 2) Print all the titles that have been published by 1389
		select title
		from titles
		where YEAR(pubdate) <= 1389;

 
-- 3) Print the books that have price in rangeof 10 to 15
		select *
		from titles
		where price between 10 and 15;
		
 
-- 4) Print those books that have no price
		select *
		from titles
		where price is NULL;
 
-- 5) Print the book names that strat with 'The'
		select DISTINCT(title)
		from titles
		where title like 'The%';
 
-- 6) Print the book names that do not have 'v' in their name
		select DISTINCT(title)
		from titles
		where title not like '%v%';
 
-- 7) print the books sorted by the royalty
		select *
		from titles
		order by royalty;
 
-- 8) print the books sorted by publisher in descending then by types in asending then by price in descending
		select *
		from titles
		order by pub_id desc, type, price desc

 
-- 9) Print the average price of books in every type
		select type, avg(price) as "Average Price"
		from titles
		group by type;
 
-- 10) print all the types in uniques
		select DISTINCT(type)
		from titles;
 
-- 11) Print the first 2 costliest books
		select TOP 2 *
		from titles
		order by price desc;
 
-- 12) Print books that are of type business and have price less than 20 which also have advance greater than 7000
		select *
		from titles
		where type = 'business' and price < 20 and advance > 7000;


 
-- 13) Select those publisher id and number of books which have price between 15 to 25 and have 'It' in its name. Print only those which have count greater than 2. Also sort the result in ascending order of count
		select pub_id, count(*) as "book_count"
		from titles
		where (price between 15 and 25) and (title like '%It%')
		group by pub_id
		having count(*) > 2
		order by count(*)

 
-- 14) Print the Authors who are from 'CA'
		select *
		from authors
		where state = 'CA';
 
-- 15) Print the count of authors from every state
		select state, count(*) as "Number_of_Authors"
		from authors
		group by state;
