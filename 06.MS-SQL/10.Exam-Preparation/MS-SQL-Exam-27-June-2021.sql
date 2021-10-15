-- Section 1.DDL

USE master

GO

CREATE DATABASE WMS

GO

USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName  VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL,
	CONSTRAINT CHK_Clients_Phone CHECK (LEN(Phone) = 12)
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
	[Status] VARCHAR(11) NOT NULL DEFAULT 'Pending',
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE,
	CONSTRAINT CHK_Job_Status CHECK([Status] = 'In Progress' OR [Status] = 'Finished' OR [Status] = 'Pending')
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
	IssueDate DATE,
	Delivered BIT NOT NULL DEFAULT 0
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price MONEY NOT NULL,
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT NOT NULL DEFAULT 0,
	CONSTRAINT CHK_Part_Price CHECK (Price > 0 AND Price < 9999.99),
	CONSTRAINT CHK_Part_Quantity CHECK (StockQty >= 0)
)

CREATE TABLE OrderParts
(
	OrderId INT NOT NULL FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT NOT NULL FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT 1,
	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId),
	CONSTRAINT CHK_OrderParts_Quantity CHECK (Quantity >= 1)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT NOT NULL DEFAULT 1,
	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId),
	CONSTRAINT CHK_PartsNeeded_Quantity CHECK (Quantity >= 1)
)

GO

-- Section 2.DML

-- 2.Insert

INSERT INTO Clients (FirstName, LastName, Phone)
VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell',	'908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie',	'Knipp','805-690-1682'),
('Candida',	'Corbley',	'908-275-8357')

INSERT INTO Parts (SerialNumber, Description, Price, VendorId)
VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

GO

-- 3.Update

UPDATE Jobs
SET
	MechanicId = 3,
	[Status] = 'In Progress'
WHERE [Status] = 'Pending'

GO

-- 4.Delete
DELETE
FROM OrderParts
WHERE OrderId = 19

DELETE
FROM Orders
WHERE OrderId = 19

GO

-- Section 3.Querying

-- 5.Mechanic Assignments
SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic
	  ,j.[Status]
	  ,j.IssueDate
FROM Mechanics AS m
JOIN Jobs AS j
ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId
		,j.IssueDate
		,j.JobId

GO

-- 6.Current Client

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client
	  ,DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going]
	  ,j.[Status]
FROM Clients AS c
JOIN Jobs AS j
ON j.ClientId = c.ClientId
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC
	    ,c.ClientId

GO

-- 7.Mechanic Performance

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic
	  ,AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics AS m
JOIN Jobs AS j
ON j.MechanicId = m.MechanicId
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId

GO

-- 8.Available Mechanics

SELECT M.FirstName +' '+M.LastName
FROM Mechanics AS M
LEFT JOIN Jobs J on M.MechanicId = J.MechanicId
WHERE J.Status ='Finished' OR J.JobId IS NULL
ORDER BY M.MechanicId

GO

-- 9.Past Expenses

SELECT JobId
	  ,ROUND(SUM(PriceForAllItems), 2) AS Total
FROM 
(
	SELECT j.JobId
		  ,CASE
				WHEN (p.Price * op.Quantity) IS NULL THEN '0.00'
				ELSE p.Price * op.Quantity
			END AS PriceForAllItems
	FROM Jobs AS j
	LEFT JOIN Orders AS o
	ON j.JobId = o.JobId
	LEFT JOIN OrderParts AS op
	ON o.OrderId = op.OrderId
	LEFT JOIN Parts AS p
	ON op.PartId = p.PartId
	WHERE j.[Status] = 'Finished'
) AS a
GROUP BY JobId
ORDER BY Total DESC
		,JobId
 
GO

-- 10.Missing Part

SELECT *
FROM 
(
	SELECT p.PartId
		  ,p.[Description]
		  ,ISNULL(pn.Quantity, 0) AS [Required]
		  ,ISNULL(p.StockQty, 0) AS [In Stock]
		  ,ISNULL(op.Quantity, 0) AS [Ordered]
	FROM Jobs AS j
	LEFT JOIN PartsNeeded AS pn
	ON j.JobId = pn.JobId
	LEFT JOIN Parts AS p
	ON pn.PartId = p.PartId
	LEFT JOIN Orders AS o
	ON j.JobId = o.JobId
	LEFT JOIN OrderParts AS op
	ON o.OrderId = op.OrderId
	WHERE j.[Status] <> 'Finished'
) AS a
WHERE [Required] > ([In Stock] + Ordered)
ORDER BY PartId

GO

-- Section 4.Programmability

-- 11.Place Order

CREATE OR ALTER PROCEDURE usp_PlaceOrder
	@jodId INT
   ,@partSerialNumber VARCHAR(50)
   ,@quantity INT
AS
BEGIN
	BEGIN TRANSACTION
		
		DECLARE @orderId INT;
		DECLARE @partId INT;

		IF @jodId < 0 OR @jodId > (SELECT COUNT(JobId) FROM Jobs)
		BEGIN
			ROLLBACK;
			THROW 50013, 'Job not found!', 1
		END

		IF (SELECT [Status] FROM Jobs WHERE JobId = @jodId) = 'Finished'
		BEGIN
			ROLLBACK;
			THROW 50011, 'This job is not active!', 1
		END

		IF @quantity <= 0
		BEGIN
			ROLLBACK;
			THROW 50012, 'Part quantity must be more than zero!', 1
		END

		IF (SELECT COUNT(PartId) FROM Parts WHERE SerialNumber = @partSerialNumber) = 0
		BEGIN
			ROLLBACK;
			THROW 50014, 'Part not found!', 1;
		END

		IF (SELECT COUNT(OrderId) FROM Orders WHERE JobId = @jodId AND IssueDate IS NULL) >= 1
		BEGIN

			SET @orderId  = (SELECT TOP(1) OrderId FROM Orders WHERE JobId = @jodId);
			SET @partId = (SELECT PartId FROM Parts WHERE SerialNumber = @partSerialNumber)

			IF (SELECT COUNT(OrderId) FROM OrderParts WHERE PartId = @partId AND OrderId = @orderId) >= 1
			BEGIN
				UPDATE OrderParts
				SET
					Quantity += @quantity
				WHERE OrderId = @orderId AND PartId = @partId

				COMMIT
			END
			ELSE
			BEGIN
			
				INSERT INTO OrderParts(OrderId, PartId, Quantity)
				VALUES (@orderId, @partId, @quantity)

				COMMIT
			END
		END
		ELSE
		BEGIN
			
			INSERT INTO Orders(JobId, IssueDate)
			VALUES (@jodId, NULL)

			SET @orderId  = (SELECT TOP(1) OrderId FROM Orders WHERE JobId = @jodId);
			SET @partId = (SELECT PartId FROM Parts WHERE SerialNumber = @partSerialNumber)

			INSERT INTO OrderParts(OrderId, PartId, Quantity)
			VALUES (@orderId, @partId, @quantity)

			COMMIT
		END
END

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 46, 'DC60-40137A', 1
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

GO

-- 12.Cost of Order

CREATE FUNCTION udf_GetCost
(
	@jobId INT
)
RETURNS DECIMAL(18,2)
AS
BEGIN
	IF (SELECT COUNT(OrderId) FROM Orders WHERE JobId = @jobId) = 0
	BEGIN

		--INSERT INTO @result
		--SELECT @jobId, 0.00

		RETURN 0.00
	END
	
	--INSERT INTO @result
	
	DECLARE @result DECIMAL(18,2) = (SELECT SUM(ItemFinalPrice) AS Result
							 FROM 
							 (
							 	  SELECT o.JobId, p.Price * op.Quantity AS ItemFinalPrice
							 	  FROM Orders AS o
							 	  JOIN OrderParts AS op
							 	  ON o.OrderId = op.OrderId
							 	  JOIN Parts AS p
							 	  ON op.PartId = p.PartId
							 	  WHERE o.JobId = @jobId
							 ) AS a
		                     GROUP BY JobId)
	RETURN @result
END

GO

SELECT dbo.udf_GetCost(1)