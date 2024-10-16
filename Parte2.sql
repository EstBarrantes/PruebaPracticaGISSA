Use WideWorldImporters

--REQ01
SELECT  OrderID, Invoices.CustomerID, Customers.CustomerName, 
		DeliveryMethods.DeliveryMethodName,Isnull(Customers.CreditLimit, -1) As CreditLimit,
		People.FullName As SalesPerson
FROM Sales.Invoices
INNER JOIN Sales.Customers ON Invoices.CustomerID = Customers.CustomerID
INNER JOIN Application.DeliveryMethods ON  Invoices.DeliveryMethodID = DeliveryMethods.DeliveryMethodID
INNER JOIN Application.People ON Invoices.SalespersonPersonID = People.PersonID
WHERE InvoiceDate BETWEEN '2013-01-01' AND '2015-12-31';

--REQ02

SELECT  Invoices.CustomerID, Customers.CustomerName, 
		COUNT(Invoices.CustomerID) As TotalFacturas,
		ROW_NUMBER() OVER (ORDER BY COUNT(Invoices.CustomerID)DESC) AS Orden
FROM Sales.Invoices
INNER JOIN Sales.Customers ON Invoices.CustomerID = Customers.CustomerID
GROUP BY Invoices.CustomerID, Customers.CustomerName
ORDER BY Orden;

