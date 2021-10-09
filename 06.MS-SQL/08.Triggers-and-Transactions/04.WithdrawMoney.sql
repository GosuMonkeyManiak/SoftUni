CREATE PROCEDURE usp_WithdrawMoney
	 @accountId INT
	,@moneyAmount MONEY
AS
BEGIN
	
	IF @accountId <= 0 OR @accountId IS NULL
	BEGIN;
		THROW 50001, 'Invalid account Id', 1;
	END
	
	IF @moneyAmount < 0 OR @moneyAmount IS NULL
	BEGIN;
		THROW 50002, 'Money ammount can not be negative or null', 1;
	END

	BEGIN TRANSACTION

		UPDATE Accounts
		SET
			Balance -= ROUND(@moneyAmount, 4)
		WHERE Id = @accountId

		IF @@ROWCOUNT <> 1
			ROLLBACK
	COMMIT

END