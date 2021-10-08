CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan
	@balanced MONEY
AS
BEGIN
	SELECT ah.FirstName, ah.LastName
	FROM AccountHolders AS ah
	JOIN Accounts AS c
	ON ah.Id = c.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(Balance) > @balanced
	ORDER BY ah.FirstName,
			 ah.LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 100000