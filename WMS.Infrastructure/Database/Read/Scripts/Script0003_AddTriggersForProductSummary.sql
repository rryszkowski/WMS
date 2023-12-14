DELIMITER //

CREATE TRIGGER add_new_product
    AFTER INSERT ON Product
    FOR EACH ROW 
BEGIN
    INSERT INTO ProductSummary (Id, Name, Category, Manufacturer, AvailableQuantity)
    SELECT NEW.Id, NEW.Name, NEW.Category, NEW.Manufacturer, 0
    FROM Product P
    WHERE P.Id = NEW.Id;
END//

CREATE TRIGGER remove_product_record
    AFTER DELETE ON Product
    FOR EACH ROW
BEGIN
    DELETE FROM ProductSummary
    WHERE Id = OLD.Id;
END//

CREATE TRIGGER update_available_quantity_insert
    AFTER INSERT ON Inventory
    FOR EACH ROW
BEGIN
    UPDATE ProductSummary
    SET AvailableQuantity = AvailableQuantity + NEW.Quantity
    WHERE Id = NEW.ProductId;
END//

CREATE TRIGGER update_available_quantity_update
    AFTER UPDATE ON Inventory
    FOR EACH ROW
BEGIN
    UPDATE ProductSummary
    SET AvailableQuantity = AvailableQuantity + NEW.Quantity - OLD.Quantity
    WHERE Id = NEW.ProductId;
END//

DELIMITER ;