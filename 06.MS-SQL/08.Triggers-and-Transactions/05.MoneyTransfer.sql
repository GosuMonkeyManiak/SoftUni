CREATE PROCEDURE usp_TransferMoney
	 @senderId INT
	,@receiverId INT
	,@amount MONEY
AS
BEGIN
	BEGIN TRANSACTION

		IF @senderId <= 0 OR @senderId IS NULL
		BEGIN
			ROLLBACK;
			THROW 50001, 'Invalid sender Id', 1; 
		END
	
		IF @receiverId <= 0 OR @receiverId IS NULL
		BEGIN
			ROLLBACK;
			THROW 50002, 'Invalid receiver Id', 1;
		END

		IF @amount < 0 OR @amount IS NULL
		BEGIN
			ROLLBACK;
			THROW 50003, 'Money ammount can not be negative or null', 1;
		END

		EXEC usp_WithdrawMoney @senderId, @amount

		EXEC usp_DepositMoney @receiverId, @amount

	COMMIT;
END