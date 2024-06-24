INSERT INTO Users (UserName, Email, PasswordHash, Role)
VALUES ('johndoe', 'john.doe@example.com', HASHBYTES('SHA2_256', 'password123'), 'Client');

INSERT INTO Craftworks (Name, Category, Price, Availability)
VALUES ('Handmade Vase', 'Ceramics', 75.00, 1);

INSERT INTO Orders (UserId, OrderDate)
VALUES (1, GETDATE());

INSERT INTO OrderItems (OrderId, CraftworkId, Quantity)
VALUES (1, 1, 2);

SELECT * FROM Craftworks WHERE Availability = 1;

SELECT o.Id, o.OrderDate, c.Name, c.Price, oi.Quantity
FROM Orders o
JOIN OrderItems oi ON o.Id = oi.OrderId
JOIN Craftworks c ON oi.CraftworkId = c.Id
DECLARE @UserId INT;

SELECT o.Id, u.UserName, u.Email, o.OrderDate, c.Name, oi.Quantity
FROM Orders o
JOIN Users u ON o.UserId = u.Id
JOIN OrderItems oi ON o.Id = oi.OrderId
JOIN Craftworks c ON oi.CraftworkId = c.Id;
