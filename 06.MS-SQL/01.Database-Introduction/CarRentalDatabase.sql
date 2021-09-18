CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[CategoryName] VARCHAR(50) NOT NULL,
	[DailyRate] TINYINT NOT NULL,
	[WeeklyRate] TINYINT NOT NULL,
	[MonthlyRate] TINYINT NOT NULL,
	[WeekendRate] TINYINT NOT NULL
);

INSERT INTO [Categories] ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate])
VALUES ('Sedan', 10, 10, 10, 10),
       ('Coupe', 9, 9, 8, 7),
	   ('Sport', 5, 4, 5, 3);

CREATE TABLE [Cars]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[PlateNumber] NVARCHAR(20) NOT NULL,
	[Manufacture] NVARCHAR(40) NOT NULL,
	[Model] NVARCHAR(20) NOT NULL,
	[CarYear] DATE NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories] ([Id]) NOT NULL,
	[Doors] TINYINT NOT NULL,
	[Picture] VARBINARY(MAX),
	[Condition] VARCHAR(20) NOT NULL,
	[Avaliable] VARCHAR(3) NOT NULL
);

INSERT INTO [Cars] ([PlateNumber], [Manufacture], [Model], [CarYear], [CategoryId], [Doors], [Condition], [Avaliable])
VALUES ('PB2128PM', 'Citroen', 'C3', '2003-1-10', 1, 5, 'very good', 'Yes'),
	   ('PB2378PX', 'Mercedes', 'C200', '2004-5-10', 2, 5, 'very good', 'Yes'),
	   ('PB0349MN', 'Lancia', 'Kappa', '1992-8-4', 3, 5, 'good', 'No');

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[FirstName] VARCHAR(50) NOT NULL,
	[LastName] VARCHAR(50) NOT NULL,
	[Title] VARCHAR(20),
	[Notes] VARCHAR(120),
);

INSERT INTO [Employees] ([FirstName], [LastName])
Values ('Dimitar', 'Kupanov'),
	   ('Ekaterina', 'Sotirova'),
	   ('Ivan', 'Kupanov');

CREATE TABLE [Customers]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[DriverLicenceNumber] BIGINT NOT NULL,
	[FullName] VARCHAR(80) NOT NULL,
	[Adress] VARCHAR(50),
	[City] VARCHAR(50) NOT NULL,
	[ZIPCode] SMALLINT,
	[Notes] VARCHAR(120)
);

INSERT INTO [Customers] ([DriverLicenceNumber], [FullName], [City])
VALUES (7890657309, 'Vanesa Tincheva', 'Plovdiv'),
	   (8790653478, 'Pesho Dimitrov', 'Sofia'),
	   (1267894901, 'Natali Ivancheva', 'Varna');

CREATE TABLE [RentalOrders]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees] ([Id]) NOT NULL,
	[CustomerId] INT FOREIGN KEY REFERENCES [Customers] ([Id]) NOT NULL,
	[CarId] INT FOREIGN KEY REFERENCES [Cars] ([Id]) NOT NULL,
	[TankLevel] TINYINT NOT NULL,
	[KilometarageStart] INT NOT NULL,
	[KilometarageEnd] INT NOT NULL,
	[TotalKilometrage] INT NOT NULL,
	[StartDate] DATE NOT NULL,
	[EndDate] DATE NOT NULL,
	[TotalDays] INT NOT NULL,
	[RateApllied] TINYINT,
	[TaxRate] INT,
	[OrderStatus] VARCHAR(15) NOT NULL,
	[Notes] VARCHAR(120)
);

INSERT INTO [RentalOrders] ([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometarageStart],
							[KilometarageEnd], [TotalKilometrage], [StartDate], [EndDate],
							[TotalDays], [OrderStatus])
VALUES (1, 1, 1, 40, 200000, 200100, 200100, '2021-1-1', '2021-1-10', 9, 'Shipped'),
	   (2, 2, 2, 45, 120000, 145000, 145000, '2020-1-1', '2021-1-1', 365, 'Complete'),
	   (3, 3, 3, 50, 30000, 300001, 300200, '2021-6-1', '2021-6-2', 1, 'End');