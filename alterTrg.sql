ALTER TRIGGER trg_ReorderBikes
ON Bikesinv
AFTER UPDATE
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Orders (BikeID, SupplierID, OrderQuantity, Status)
    SELECT BikeID, SupplierID, 10, 'Ordered'
    FROM inserted
    WHERE Quantity < 4 AND BikeID NOT IN (
        SELECT BikeID 
        FROM Orders 
        WHERE Status = 'Ordered'
    );

    UPDATE Bikesinv
    SET Quantity = Quantity + 10
    WHERE BikeID IN (
        SELECT BikeID 
        FROM inserted
        WHERE Quantity < 4
    );
END;
