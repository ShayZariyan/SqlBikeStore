CREATE TABLE Customers (
    CustomerID INT PRIMARY KEY IDENTITY(1,1),
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    PhoneNumber NVARCHAR(20) NOT NULL,
    Address NVARCHAR(255) NOT NULL
);

INSERT INTO Customers (FirstName, LastName, PhoneNumber, Address)
VALUES 
('Meni', 'Mamtera', '0527778924', 'Banana 4'),
('Yuval', 'Crazy', '0502248976', 'Apple 5'),
('Dana', 'Gan', '0549992341', 'Mango 2');

CREATE TABLE Suppliers (
    SupplierID INT PRIMARY KEY IDENTITY(1,1),
    SupplierName NVARCHAR(50) NOT NULL,
    SupplierCountry NVARCHAR(50) NOT NULL
);

INSERT INTO Suppliers (SupplierName, SupplierCountry)
VALUES 
('China Supplier', 'China'),
('Israel Supplier', 'Israel'),
('USA Supplier', 'USA');

CREATE TABLE Bikesinv (
    BikeID INT PRIMARY KEY IDENTITY(1,1),
    BikeType NVARCHAR(50) NOT NULL,
    Color NVARCHAR(50) NOT NULL,
    Size NVARCHAR(10) NOT NULL,
    Quantity INT NOT NULL,
    SupplierID INT NOT NULL FOREIGN KEY REFERENCES Suppliers(SupplierID)
);

INSERT INTO Bikesinv (BikeType, Color, Size, Quantity, SupplierID)
VALUES
('Race', 'Red', '29"', 5, 1),
('Race', 'Red', '26"', 5, 1),
('Race', 'Red', '14"', 5, 1),
('Race', 'Black', '29"', 5, 1),
('Race', 'Black', '26"', 5, 1),
('Race', 'Black', '14"', 5, 1),
('Race', 'Yellow', '29"', 5, 1),
('Race', 'Yellow', '26"', 5, 1),
('Race', 'Yellow', '14"', 5, 1),
('Road', 'Red', '29"', 5, 2),
('Road', 'Red', '26"', 5, 2),
('Road', 'Red', '14"', 5, 2),
('Road', 'Black', '29"', 5, 2),
('Road', 'Black', '26"', 5, 2),
('Road', 'Black', '14"', 5, 2),
('Road', 'Yellow', '29"', 5, 2),
('Road', 'Yellow', '26"', 5, 2),
('Road', 'Yellow', '14"', 5, 2),
('Kids', 'Red', '29"', 5, 3),
('Kids', 'Red', '26"', 5, 3),
('Kids', 'Red', '14"', 5, 3),
('Kids', 'Black', '29"', 5, 3),
('Kids', 'Black', '26"', 5, 3),
('Kids', 'Black', '14"', 5, 3),
('Kids', 'Yellow', '29"', 5, 3),
('Kids', 'Yellow', '26"', 5, 3),
('Kids', 'Yellow', '14"', 5, 3);


CREATE TABLE Sales (
    SaleID INT PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL FOREIGN KEY REFERENCES Customers(CustomerID),
    BikeID INT NOT NULL FOREIGN KEY REFERENCES Bikesinv(BikeID),
    Quantity INT NOT NULL,
    TotalPrice DECIMAL(10, 2) NOT NULL,
    SaleDate DATETIME DEFAULT GETDATE()
);


INSERT INTO Sales (CustomerID, BikeID, Quantity, TotalPrice)
VALUES
(1, 1, 2, 1000.00),
(2, 10, 1, 500.00), 
(3, 19, 3, 1500.00);


CREATE TABLE Orders (
    OrderID INT PRIMARY KEY IDENTITY(1,1),
    BikeID INT NOT NULL FOREIGN KEY REFERENCES Bikesinv(BikeID),
    SupplierID INT NOT NULL FOREIGN KEY REFERENCES Suppliers(SupplierID),
    OrderQuantity INT NOT NULL,
    OrderDate DATETIME DEFAULT GETDATE(),
    Status NVARCHAR(50) DEFAULT 'Pending'
);


CREATE TRIGGER trg_ReorderBikes
ON Bikesinv
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Orders (BikeID, SupplierID, OrderQuantity)
    SELECT BikeID, SupplierID, 10 -- 
    FROM inserted
    WHERE Quantity < 4 AND BikeID NOT IN (
        SELECT BikeID 
        FROM Orders 
        WHERE Status = 'Pending'
    );
END;

	
