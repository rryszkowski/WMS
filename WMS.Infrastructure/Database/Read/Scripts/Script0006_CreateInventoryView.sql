CREATE VIEW InventoryView AS
SELECT
    ROW_NUMBER() OVER () AS InventoryViewId,
    i.ProductId,
    i.WarehouseId,
    p.Name AS ProductName,
    w.Location AS WarehouseLocation,
    SUM(i.Quantity) AS Quantity
FROM
    Inventory i
JOIN Product p ON i.ProductId = p.Id
JOIN Warehouse w ON i.WarehouseId = w.Id
GROUP BY
    i.ProductId, i.WarehouseId, p.Name, w.Location;