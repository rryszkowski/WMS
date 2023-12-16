CREATE VIEW ShipmentView AS
SELECT
    ROW_NUMBER() OVER () AS ShipmentViewId,
    s.Id AS ShipmentId,
    s.OrderId,
    s.WarehouseId,
    s.Status,
    SUM(od.Quantity) AS TotalQuantity
FROM
    Shipment s
JOIN OrderDetails od ON s.OrderId = od.OrderId
GROUP BY
    s.Id, s.OrderId, s.WarehouseId, s.Status;