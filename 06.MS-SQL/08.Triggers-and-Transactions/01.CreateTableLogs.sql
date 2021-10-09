CREATE TABLE Logs
(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
)

GO

CREATE TRIGGER tr_AddALogOnAccountUpdate
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs (AccountId, OldSum, NewSum)
	SELECT d.AccountHolderId, d.Balance, i.Balance
	FROM deleted AS d
	JOIN inserted AS i
	ON d.Id = i.Id

GO

UPDATE Accounts
SET Balance = 111.11
WHERE AccountHolderId = 1

GO

SELECT *
FROM Logs