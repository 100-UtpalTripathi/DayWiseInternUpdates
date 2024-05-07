select * from Categories

select * from Suppliers

select CategoryID,  categoryname from Categories
union
select SupplierId,CompanyName from Suppliers

select * from [Order Details]

select * from Orders where ShipCountry='Spain'
intersect
select * from orders where Freight>50

--get the order id, productname and quantitysold of products that have price
--greater than 15

select od.OrderID, p.ProductName, od.quantity as "Quantity Sold", p.UnitPrice
from [Order Details] od join products p on p.productid = od.productid
join Categories c on p.CategoryID = c.CategoryID
where (p.UnitPrice between 10 and 20) and (c.CategoryName like 'Dairy%');


select Top 10 * from (
select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
from [Order Details] od join Products p
on od.ProductId = p.ProductID
where p.UnitPrice>15
union
SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
JOIN Products p ON p.ProductID = [Order Details].ProductID
JOIN Categories c ON c.CategoryID = p.CategoryID
WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%') t order by [Quantity Sold] desc;
 
 --CTE

  with OrderDetails_CTE(OrderID,ProductName,Quantity,Price)
  as
  (select OrderID, ProductName, Quantity "Quantity Sold",p.UnitPrice
  from [Order Details] od join Products p
  on od.ProductId = p.ProductID
  where p.UnitPrice>15
  union
  SELECT OrderID, p.productname, Quantity "Quantity Sold", p.UnitPrice FROM [Order Details]
  JOIN Products p ON p.ProductID = [Order Details].ProductID
  JOIN Categories c ON c.CategoryID = p.CategoryID
  WHERE p.UnitPrice BETWEEN 10 AND 20 AND c.CategoryName LIKE '%Dairy%')

  select top 10 * from  OrderDetails_CTE order by price desc

  with orderDetailsCTE as
	(select o.OrderId, c.ContactName, p.ProductName
	from orders o join Customers c on o.CustomerID = c.CustomerID
	join [Order Details] od on o.OrderID = od.OrderId
	join Products p on od.ProductID = p.ProductID
	where c.Country = 'USA'
	Union
	select o.OrderId, c.ContactName, p.ProductName
	from orders o join Customers c on o.CustomerID = c.CustomerID
	join [Order Details] od on o.OrderID = od.OrderId
	join Products p on od.ProductID = p.ProductID
	where o.Freight < 20 and c. = 'France')

	select top 10 * from  OrderDetailsCTE;