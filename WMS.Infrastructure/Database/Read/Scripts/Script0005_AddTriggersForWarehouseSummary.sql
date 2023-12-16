DELIMITER //

CREATE TRIGGER add_new_warehouse
    AFTER INSERT ON Warehouse
    FOR EACH ROW 
BEGIN
    INSERT INTO WarehouseSummary (Id, Location, Capacity, Utilization)
    SELECT NEW.Id, NEW.Location, NEW.Capacity, 0
    FROM Warehouse W
    WHERE W.Id = NEW.Id;
END//

CREATE TRIGGER update_utilization_after_insert
    AFTER INSERT ON Inventory
    FOR EACH ROW
BEGIN
    UPDATE WarehouseSummary
    SET Utilization = Utilization + NEW.Quantity
    WHERE Id = NEW.WarehouseId;
END//

CREATE TRIGGER update_utilization_after_update
    AFTER UPDATE ON Inventory
    FOR EACH ROW
BEGIN
    UPDATE WarehouseSummary
    SET Utilization = Utilization - OLD.Quantity + NEW.Quantity
    WHERE Id = NEW.WarehouseId;
END//

CREATE TRIGGER update_utilization_after_delete
    AFTER DELETE ON Inventory
    FOR EACH ROW
BEGIN
    UPDATE WarehouseSummary
    SET Utilization = Utilization - OLD.Quantity
    WHERE Id = OLD.WarehouseId;
END//

DELIMITER ;