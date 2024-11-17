INSERT INTO Products VALUES
('Laptop', 999.99),
('Smartphone', 499.99),
('Headphones', 89.99)

SELECT * FROM Baskets
SELECT * FROM Users
SELECT * FROM Products

SELECT Baskets.Id, Users.Username, Products.Name ,Products.Price FROM Baskets
INNER JOIN Users ON Baskets.UserId = Users.Id
INNER JOIN Products ON Baskets.ProductId = Products.Id