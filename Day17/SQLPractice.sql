select * from Categories

select CategoryId from Categories where CategoryName = 'Confections'

--All the products from 'Confections'
select * from products where CategoryID = 
(select CategoryId from Categories where CategoryName = 'Confections')

select * from Suppliers

select * from products

select * from categories;

--select product names from the supplier Tokyo Traders


select ProductName from products
where SupplierId = (select supplierID from suppliers where companyname = 'Tokyo Traders')


--get all the products from the category that has 'ea' in the description

select ProductName from products
where categoryID in (select categoryID from categories where description like '%ea%')

select * from products where CategoryID in
(select CategoryID from Categories where Description like '%ea%')
and SupplierID = 
(select SupplierID from Suppliers where CompanyName = 'Tokyo Traders')

select * from customers

--select the product id and the quantity ordered by customrs from France

select customerid from customers where country = 'France'

--Get the products that are priced above the average price of all the products
select * from products where unitprice > (select avg(Unitprice) from products)



select * from orders o1
where orderdate = 
(select max(orderdate) from orders o2
where o2.EmployeeID = o1.employeeid)
order by o1.EmployeeID

select * from products p1
where UnitPrice = (select max(UnitPrice) from products p2 where p1.categoryID = p2.categoryID)
order by p1.categoryID

select * from 
(
	select *, RANK() over (partition by categoryid order by unitprice desc) as "Rank" from products
) as temp
where Rank = 1


select * from 
(
	select *, RANK() over (partition by customerid order by Freight desc) as "Rank" from orders
) as temp
where Rank = 1


--cross join
select * from Categories,customers

--Inner join
select * from categories where CategoryID 
not in (select distinct categoryid from products)

select * from Suppliers where SupplierID 
not in (select distinct SupplierID from products)

--Get teh categoryId and teh productname
select CategoryId,ProductName from products

--Get teh categoryname and the productname
select categoryName,ProductName from Categories 
inner join Products on Categories.CategoryID = Products.CategoryID


--Get the Supplier company name, contact person name, Product name and the stock ordered
select companyname, contactName, productName, UnitsOnOrder
from suppliers inner join products on suppliers.supplierid = products.supplierid

--Print the order id, customername and the fright cost for all teh orders

 select orderid, contactname, freight
 from orders inner join customers on orders.customerid = customers.customerid


  --product name, quantity sold, Discount Price, Order Id, Fright for all orders
 select o.OrderID "Order ID",p.Productname, od.Quantity "Quantity Sold",
 (p.UnitPrice*od.Quantity) "Base Price", 
 ((p.UnitPrice*od.Quantity)-((p.UnitPrice*od.Quantity)* od.Discount/100)) "Discounted price",
 Freight "Freight Charge"
 from Orders o join Orderdetails od
 on o.OrderID = od.OrderID
 join Products p on p.ProductID = od.ProductID
 order by o.OrderID


 --select customer name, product name, quantity sold and the frieght, 
 --total price(unitpice*quantity+freight)

 select c.contactName, p.productName, od.quantity ,o.freight, p.UnitPrice*od.quantity+o.freight  as "Total Price"
 from orders o join customers c on o.customerid = c.customerid 
 join orderdetails od on od.orderid = o.orderid
 join products p on p.productid = od.productid
 order by [Total Price];

 --Print the product name and the total quantity sold
 select productName,sum(quantity) "Total quantity sold"
 from products p join [Order Details] od
 on p.ProductID = od.ProductID
 group by ProductName
 order by 2 desc


 select c.ContactName, o.OrderId, count(*) as "No. of Products per Order"
 from customers c join orders o on c.customerid = o.CustomerID
 join orderdetails od on o.OrderID = od.OrderID
 group by c.ContactName,o.OrderID

 select concat(e.FirstName, ' ', e.LastName) as "Employee Name", contactname, p.productName, sum(od.Quantity*p.UnitPrice) as "Total Price"
from employees e join orders o on e.EmployeeID = o.EmployeeID
join customers c on c.customerid = o.CustomerID
join orderdetails od on od.orderid = o.OrderID
join products p on p.ProductID = od.productid
group by concat(e.FirstName, ' ', e.LastName), contactname, p.ProductName



