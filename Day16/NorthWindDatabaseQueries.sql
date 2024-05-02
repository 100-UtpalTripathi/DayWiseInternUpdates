use NorthWind

select * from Products

select ProductName, QuantityPerUnit from Products

select ProductName Name_Of_Product, QuantityPerUnit as Quantity_Per_Unit from Products

select ProductName 'Name Of Product', QuantityPerUnit as Quantity_Per_Unit from Products

--Select all the products that are out of stock
select * from Products where UnitsInStock=0

--select the products that will no more be stocked
select * from products where Discontinued =1

--Select Products that will be in clearance
select * from products where Discontinued =1 and UnitsInStock>0

select * from products where unitprice between 10 and 30
--(or)
select * from products where unitprice>=10 and unitprice<=30


select avg(UnitPrice*UnitsInStock) as "Average Price" from products where SupplierID = 2;

select sum(UnitsOnOrder*UnitPrice) as "Worth of Products in Order" from products

select * from products;

select SupplierId, avg(UnitPrice) as "Average Price" from products group by SupplierId

select supplierID,
ProductName,
sum(unitsinstock) 'Items in stock',
avg(unitprice) 'Average PRice'
from products
group by supplierID, ProductName;

select * from products

select CategoryID, count(*) as Sum_of_Products 
from products
group by categoryID
having Sum_of_Products  > 10;

select ProductName, UnitPrice
from products
where Discontinued = 1
order by UnitPrice

select CategoryId, sum(UnitPrice) 'Total Price'
from Products
where Discontinued != 1
group by CategoryId
Having sum(UnitPrice)>200
order by 2

select ProductName,
Rank() over( order by UnitPrice desc) "Price Rank"
from Products

select * from customers

select ContactName, 
RANK() over (partition by Country order by Country)
from customer;