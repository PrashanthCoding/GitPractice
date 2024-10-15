SELECT * FROM Customers
WHERE NOT Country = 'Australia';

SELECT * FROM Customers
WHERE CustomerID NOT BETWEEN 10 AND 60;

SELECT * FROM Customers
WHERE City NOT IN ('Paris', 'London');

SELECT * FROM Customers
WHERE NOT CustomerID > 50;
