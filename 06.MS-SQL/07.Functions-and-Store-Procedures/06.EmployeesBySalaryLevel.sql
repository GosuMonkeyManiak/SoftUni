CREATE PROCEDURE usp_EmployeesBySalaryLevel
	@SalaryLevel NVARCHAR(10)
AS
BEGIN
	SELECT e.FirstName, e.LastName 
	FROM 
	(
		SELECT *, dbo.udf_GetSalaryLevel(Salary) AS SalaryLevel
		FROM Employees
	) AS e
	WHERE SalaryLevel = @SalaryLevel
END

EXEC usp_EmployeesBySalaryLevel
	@SalaryLevel = 'High'