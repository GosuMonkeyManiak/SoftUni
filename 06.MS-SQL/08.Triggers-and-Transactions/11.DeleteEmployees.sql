CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NOT NULL,
	JobTitle VARCHAR(50) NOT NULL,
	DepartmentId INT NOT NULL,
	Salary MONEY NOT NULL
)

GO

CREATE TRIGGER tr_WhenDeleteEmployeeAddToDeletedTable
ON Employees
AFTER DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT FirstName
		  ,LastName
		  ,MiddleName
		  ,JobTitle
		  ,DepartmentID
		  ,Salary
	FROM deleted
END