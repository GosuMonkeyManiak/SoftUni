CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber 
	@SalaryNumber DECIMAL(18, 4)
AS
BEGIN
	SELECT FirstName, LastName
	FROM Employees
	WHERE Salary >= @SalaryNumber
END

EXEC usp_GetEmployeesSalaryAboveNumber 48100