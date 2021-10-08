CREATE PROCEDURE usp_CalculateFutureValueForAccount
	@accountId INT,
	@interestRate FLOAT
AS
BEGIN
	SELECT TOP(1)
		   ah.Id AS [Account Id]
		  ,ah.FirstName AS [First Name]
		  ,ah.LastName AS [Last Name]
		  ,a.Balance AS [Current Balance]
		  ,dbo.udf_CalcualteFutureValue(a.Balance, @interestRate, 5) AS [Balance in 5 years]
	FROM AccountHolders AS ah
	JOIN Accounts AS a
	ON ah.Id = a.AccountHolderId
	WHERE ah.Id = @accountId
END