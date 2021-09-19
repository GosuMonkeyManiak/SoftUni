CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[Title] NVARCHAR(20),
	[Notes] NVARCHAR(120)
);

INSERT INTO [Employees] ([FirstName], [LastName])
VALUES ('Dimitar', 'Kupanov'),
	   ('Ivan', 'Kupanov'),
	   ('Nina', 'Kupanova');

CREATE TABLE [Customers]
(
	[AccountNumber] INT PRIMARY KEY IDENTITY(1, 1),
	[FirstName] NVARCHAR(50) NOT NULL,
	[LastName] NVARCHAR(50) NOT NULL,
	[PhoneNumber] BIGINT NOT NULL,
	[EmergencyName] NVARCHAR(50),
	[EmergencyNumber] BIGINT NOT NULL,
	[Notes] NVARCHAR(150)
);

INSERT INTO [Customers] ([FirstName], [LastName], [PhoneNumber], [EmergencyNumber])
VALUES ('Stanimira', 'Kupanov', 0897456710, 112),
	   ('Ekaterina', 'Sotirova', 0879645301, 911),
	   ('Dimitar', 'Chokov', 0865478931, 112);

CREATE TABLE [RoomStatus]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[RoomStatus] NVARCHAR(40) NOT NULL,
	[Notes] NVARCHAR(120)
);

INSERT INTO [RoomStatus] ([RoomStatus])
VALUES ('Busy'),
	   ('Not bussy'),
	   ('In Repair');

CREATE TABLE [RoomTypes]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[RoomType] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(120)
);

INSERT INTO [RoomTypes] ([RoomType])
VALUES ('Apartment'),
	   ('Two rooms'),
	   ('There rooms');

CREATE TABLE [BedTypes]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[BedType] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(120)
);

INSERT INTO [BedTypes] ([BedType])
VALUES ('Single Bed'),
	   ('Full Bed'),
	   ('Army Bed');

CREATE TABLE [Rooms]
(
	[RoomNumber] INT PRIMARY KEY IDENTITY(1, 1),
	[RoomType] INT FOREIGN KEY REFERENCES [RoomTypes] ([Id]) NOT NULL,
	[BedType] INT FOREIGN KEY REFERENCES [BedTypes] ([Id]) NOT NULL,
	[Rate] TINYINT,
	[RoomStatus] INT FOREIGN KEY REFERENCES [RoomStatus] ([Id]) NOT NULL,
	[Notes] NVARCHAR(120)
);

INSERT INTO [Rooms] ([RoomType], [BedType], [RoomStatus])
Values (1, 1, 1),
	   (2, 2, 2),
	   (3, 3, 3);

CREATE TABLE [Payments]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
	[PaymentDate] DATETIME2 NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers] ([AccountNumber]) NOT NULL,
	[FirstDateOccupied] DATE NOT NULL,
	[LastDateOccupied] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[AmmountCharged] INT NOT NULL,
	[TaxRate] INT,
	[PaymentTotal] INT NOT NULL,
	[Notes] NVARCHAR(120)
);

INSERT INTO [Payments] ([EmployeeId], [PaymentDate], [AccountNumber], [FirstDateOccupied],
	                    [LastDateOccupied], [TotalDays], [AmmountCharged], [PaymentTotal])
VALUES (1, '2021-01-01', 1, '2021-01-01', '2021-01-01', 1, 100, 150),
	   (2, '2021-01-01', 2, '2021-01-01', '2021-01-01', 1, 100, 150),
	   (3, '2021-01-01', 3, '2021-01-01', '2021-01-01', 1, 100, 150)

CREATE TABLE [Occupancies]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
	[DateOccupied] INT NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES [Customers] ([AccountNumber]) NOT NULL,
	[RoomNumber] INT FOREIGN KEY REFERENCES [Rooms] ([RoomNumber]) NOT NULL,
	[RateApplied] TINYINT,
	[PhoneCharge] TINYINT,
	[Note] NVARCHAR(120)
);

INSERT INTO [Occupancies] ([EmployeeId], [DateOccupied], [AccountNumber], [RoomNumber])
VALUES (1, 10, 1, 1),
	   (2, 12, 2, 2),
	   (3, 13, 3, 3);