CREATE TABLE NotificationEmails
(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL,
	[Subject] NVARCHAR(200) NOT NULL,
	Body NVARCHAR(200) NOT NULL
)

GO

CREATE TRIGGER tr_AddaNotificationEmailOnInsert
ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails (Recipient, [Subject], Body)
	SELECT AccountId
		  ,CONCAT('Balance change for account: ', AccountId)
		  ,CONCAT('On ', Format(GETDATE(), 'dddd MM yyyy hh:mm tt'), ' your balance was changed from ', OldSum, ' to ', NewSum)
	FROM inserted

GO

UPDATE Accounts
SET Balance = 111.21
WHERE AccountHolderId = 1