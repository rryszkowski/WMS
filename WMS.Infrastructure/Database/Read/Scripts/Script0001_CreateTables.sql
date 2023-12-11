CREATE TABLE Customer (
    Id CHAR(36) PRIMARY KEY,
    Name VARCHAR(100)
);

CREATE TABLE Product (
    Id CHAR(36) PRIMARY KEY,
    Name VARCHAR(100),
    Category VARCHAR(100),
    Manufacturer VARCHAR(100)
);

CREATE TABLE Warehouse (
    Id CHAR(36) PRIMARY KEY,
    Location VARCHAR(100),
    Capacity INT
);

CREATE TABLE Inventory (
    Id CHAR(36) PRIMARY KEY,
    WarehouseId CHAR(36),
    ProductId CHAR(36),
    Quantity INT,
    FOREIGN KEY (WarehouseId) REFERENCES Warehouse(Id)
);

CREATE TABLE `Order` (
    Id CHAR(36) PRIMARY KEY,
    CustomerId CHAR(36),
    Status VARCHAR(30),
    FOREIGN KEY (CustomerId) REFERENCES Customer(Id)
);

CREATE TABLE OrderDetails (
    Id CHAR(36) PRIMARY KEY,
    OrderId CHAR(36),
    ProductId CHAR(36),
    Quantity INT,
    FOREIGN KEY (OrderId) REFERENCES `Order`(Id),
    FOREIGN KEY (ProductId) REFERENCES Product(Id)
);

CREATE TABLE Shipment (
    Id CHAR(36) PRIMARY KEY,
    OrderId CHAR(36),
    WarehouseId CHAR(36),
    Status VARCHAR(30),
    FOREIGN KEY (OrderId) REFERENCES `Order`(Id),
    FOREIGN KEY (WarehouseId) REFERENCES Warehouse(Id)
);