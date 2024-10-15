INSERT INTO Customers (CustomerName, City, Country)
VALUES ('Cardinal', 'Sydney', 'Australia');

INSERT INTO Customers (CustomerName, ContactName, Address, City, PostalCode, Country)
VALUES
('Cardinal', 'Tom B. Erichsen', 'Skagen 21', 'Stavanger', '4006', 'Norway'),
('Greasy Burger', 'Per Olsen', 'Gateveien 15', 'Sandnes', '4306', 'Norway'),
('Tasty Tee', 'Finn Egan', 'Streetroad 19B', 'Liverpool', 'L1 0AA', 'UK');

SELECT CustomerName, ContactName, Address
FROM Customers
WHERE Address IS NULL;

SELECT * FROM Customers
LIMIT 3;

SELECT CustomerName, ContactName, Address
FROM Customers
WHERE Address IS NOT NULL;

UPDATE Customers
SET ContactName = 'Prashanth', City= 'Melbourne'
WHERE CustomerID = 1;

UPDATE Customers
SET ContactName='Prashanth'
WHERE Country='Australia';

SELECT * FROM Customers
FETCH FIRST 3 ROWS ONLY;

SELECT TOP 50 PERCENT * FROM Customers;
