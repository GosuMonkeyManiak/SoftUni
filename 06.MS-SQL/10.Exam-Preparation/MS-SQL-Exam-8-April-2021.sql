--Section 1.DDL

CREATE DATABASE [Service]

GO

USE [Service]

CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50),
	Birthdate DATETIME,
	Age INT,
	Email VARCHAR(50) NOT NULL,
	CONSTRAINT CHK_Users_Age CHECK (Age BETWEEN 14 AND 110)
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(25),
	LastName VARCHAR(25),
	Birthdate DATETIME,
	Age INT,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id),
	CONSTRAINT CHK_Employees_Age CHECK (Age BETWEEN 18 AND 110)
)

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE [Status]
(
	Id INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
)

CREATE TABLE Reports
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	StatusId INT FOREIGN KEY REFERENCES [Status](Id) NOT NULL,
	OpenDate DATETIME NOT NULL,
	CloseDate DATETIME,
	[Description] VARCHAR(200) NOT NULL,
	UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--Section 2.DML

-- 2.Insert

INSERT INTO Employees (FirstName, LastName, Birthdate, DepartmentId)
VALUES ('Marlo', 'O''Malley', '1958-9-21', 1),
	   ('Niki', 'Stanaghan', '1969-11-26', 4),
	   ('Ayrton', 'Senna', '1960-03-21', 9),
	   ('Ronnie', 'Peterson', '1944-02-14',	9),
	   ('Giovanna',	'Amati', '1959-07-20', 5)

INSERT INTO Reports (CategoryId, StatusId, OpenDate, CloseDate, [Description], UserId, EmployeeId)
VALUES (1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
	   (6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
	   (14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
	   (4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1)

-- 3.Update

UPDATE Reports
SET
	CloseDate = GETDATE()
WHERE CloseDate IS NULL

-- 4.Delete

DELETE
FROM Reports
WHERE StatusId = 4

-- Section 3.Querying

-- 5.Unassigned Reports

SELECT [Description]
	  ,FORMAT(OpenDate, 'dd-MM-yyyy') AS [OpenDate]
FROM Reports AS r
WHERE EmployeeId IS NULL
ORDER BY r.OpenDate
		,[Description]

-- 6.Reports and Categories

SELECT r.[Description]
	  ,c.[Name] AS CategoryName
FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
ORDER BY r.[Description]
		,c.[Name]

-- 7.Most Reported Category

SELECT TOP(5)
	   c.[Name] AS CategoryName
	  ,COUNT(c.[Name]) AS ReportsNumber
FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
GROUP BY c.[Name]
ORDER BY ReportsNumber DESC
		,CategoryName


-- 8.Birthday Report

SELECT u.Username
	  ,c.[Name] AS CategoryName
FROM Reports AS r
JOIN Categories AS c
ON c.Id = r.CategoryId
JOIN Users AS u
ON u.Id = r.UserId
WHERE DATEPART(MONTH,u.Birthdate) = DATEPART(MONTH,r.OpenDate) AND DATEPART(DAY,u.Birthdate) = DATEPART(DAY,r.OpenDate)
ORDER BY u.Username
	    ,CategoryName


-- 9.Users per Employee

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName
	  ,COUNT(u.Id) AS UsersCount
FROM Employees AS e
LEFT JOIN Reports as R
ON e.Id = r.EmployeeId
LEFT JOIN Users AS u
ON r.UserId = u.Id
GROUP BY e.Id,e.FirstName, e.LastName
ORDER BY UsersCount DESC
	    ,FullName

-- 10.Full info

SELECT CASE
			WHEN up.FirstName IS NULL OR up.LastName IS NULL THEN 'None'
			ELSE CONCAT(up.FirstName, ' ', up.LastName)
		END AS Employee
	  ,CASE
			WHEN d.[Name] IS NULL THEN 'None'
			ELSE d.[Name]
		END AS Department
	  ,CASE
			WHEN c.[Name] IS NULL THEN 'None'
			ELSE c.[Name]
		END AS Category
	  ,r.[Description]
	  ,FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate
	  ,s.[Label] AS [Status]
	  ,u.[Name] AS [User]
FROM Reports AS r
LEFT JOIN Categories AS c
ON r.CategoryId = c.Id
LEFT JOIN [Status] AS s
ON r.StatusId = s.Id
LEFT JOIN Users AS u
ON r.UserId = u.Id
LEFT JOIN Employees AS up
ON r.EmployeeId = up.Id
LEFT JOIN Departments AS d
ON up.DepartmentId = d.Id
ORDER BY up.FirstName DESC
		,up.LastName DESC
		,Department
		,Category
		,[Description]
		,r.OpenDate
		,[Status]
		,[User]

-- 11.Hours to Complete
GO

CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	
	IF (@StartDate IS NULL OR @EndDate IS NULL)
	BEGIN
		RETURN 0;
	END

	DECLARE @diff INT;

	SET @diff = DATEDIFF(HOUR, @StartDate, @EndDate);

	RETURN @diff
END

GO

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
FROM Reports

GO

-- 12.Assign Employee

CREATE PROCEDURE usp_AssignEmployeeToReport
	@employeeId INT
   ,@reportId INT
AS
BEGIN
	BEGIN TRANSACTION
		DECLARE @employeeDepartmentId INT = (SELECT DepartmentId FROM Employees WHERE Id = @employeeId)
		DECLARE @reportCategoryDepartmendId INT = (SELECT c.DepartmentId FROM Reports AS r JOIN Categories AS c ON r.CategoryId = c.Id WHERE r.Id = @reportId)

		IF @employeeDepartmentId <> @reportCategoryDepartmendId
		BEGIN
			ROLLBACK;
			THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1
		END

		UPDATE Reports
		SET
			EmployeeId = @employeeId
		WHERE Id = @reportId

	COMMIT
END

GO

EXEC usp_AssignEmployeeToReport 30, 1
EXEC usp_AssignEmployeeToReport 17, 2
