CREATE VIEW OrderView AS
SELECT
    ROW_NUMBER() OVER () AS OrderViewId,
    o.Id AS OrderId,
    o.CustomerId,
    o.Status,
    SUM(od.Quantity) AS TotalQuantity,
    COUNT(od.ProductId) AS TotalProducts
FROM
    `Order` o
JOIN OrderDetails od ON o.Id = od.OrderId
GROUP BY
    o.Id, o.CustomerId, o.Status;