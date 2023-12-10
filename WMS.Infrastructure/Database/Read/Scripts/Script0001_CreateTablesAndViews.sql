CREATE TABLE ProductSummary (
    Id CHAR(36) PRIMARY KEY,
    Name VARCHAR(255),
    Category VARCHAR(100),
    Manufacturer VARCHAR(100),
    AvailableQuantity INT
);

CREATE TABLE WarehouseSummary (
    Id CHAR(36) PRIMARY KEY,
    Location VARCHAR(255),
    Capacity INT,
    Utilization INT
);

CREATE TABLE InventorySummary (
    Id CHAR(36) PRIMARY KEY,
    ProductId CHAR(36),
    WarehouseId CHAR(36),
    ProductName VARCHAR(255),
    WarehouseLocation VARCHAR(100),
    Quantity INT
);

CREATE TABLE OrderSummary (
    Id CHAR(36) PRIMARY KEY,
    OrderId CHAR(36),
    CustomerId CHAR(36),
    Status VARCHAR(30),
    TotalQuantity INT,
    TotalProducts INT
);

CREATE TABLE ShipmentSummary(
    Id CHAR(36) PRIMARY KEY,
    ShipmentId CHAR(36),
    OrderId CHAR(36),
    WarehouseId CHAR(36),
    Status VARCHAR(30),
    TotalQuantity INT
);