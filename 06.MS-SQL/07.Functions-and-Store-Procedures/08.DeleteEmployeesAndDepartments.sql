CREATE PROCEDURE usp_DeleteEmployeesFromDepartment
	@departmentId INT
AS
BEGIN

	ALTER TABLE EmployeesProjects
		DROP CONSTRAINT FK_EmployeesProjects_Employees

	ALTER TABLE Departments
		DROP CONSTRAINT FK_Departments_Employees

	ALTER TABLE Employees
		DROP CONSTRAINT FK_Employees_Departments

	ALTER TABLE Employees
		DROP CONSTRAINT FK_Employees_Employees
	
	DELETE
	FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE 
	FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
	FROM Employees AS e
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
	WHERE e.DepartmentID = @departmentId
END

EXEC usp_DeleteEmployeesFromDepartment 7