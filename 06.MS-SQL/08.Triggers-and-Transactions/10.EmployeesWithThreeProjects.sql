CREATE PROCEDURE usp_AssignProject
	 @employeeId INT
	,@projectId INT
AS
BEGIN
	BEGIN TRANSACTION

		INSERT INTO EmployeesProjects(EmployeeID, ProjectID)
		VALUES (@employeeId, @projectId)

		DECLARE @numberOfProjectAssigned INT = (SELECT COUNT(EmployeeID) FROM EmployeesProjects WHERE EmployeeID = @employeeId)

		IF (@numberOfProjectAssigned > 3)
		BEGIN
			ROLLBACK;
			RAISERROR('The employee has too many projects!', 16, 1);
		END
	COMMIT
END