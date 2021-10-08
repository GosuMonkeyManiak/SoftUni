CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END

EXEC usp_GetHoldersFullName