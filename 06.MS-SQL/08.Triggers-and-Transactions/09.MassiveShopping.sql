DECLARE @userName NVARCHAR(50) = 'Stamat'
DECLARE @userGame NVARCHAR(50) = 'Safflower'
DECLARE @userID INT = (SELECT Id FROM Users WHERE Username = @userName)
DECLARE @gameID INT = (SELECT Id FROM Games WHERE [Name] = @userGame)
DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userID AND GameId = @gameID)
DECLARE @allMoneyForGame MONEY = (SELECT Cash FROM UsersGames WHERE UserId = @userID AND GameId = @gameID)
DECLARE @moneyForAllItems11And12 MONEY = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)
DECLARE @moneyForAllItems19And21 MONEY = (SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)

BEGIN TRANSACTION
	
	IF @allMoneyForGame - @moneyForAllItems11And12 >= 0
	BEGIN

		UPDATE UsersGames
		SET
			Cash = @allMoneyForGame - @moneyForAllItems11And12
		WHERE UserId = @userID 
			  AND GameId = @gameID

		SET @allMoneyForGame = @allMoneyForGame - @moneyForAllItems11And12;

		INSERT INTO UserGameItems (UserGameId, ItemId)
		SELECT @userGameId, items.Id
		FROM (SELECT Id FROM Items WHERE MinLevel BETWEEN 11 AND 12) AS items

		COMMIT
	END

	ELSE
	BEGIN
		ROLLBACK TRANSACTION
	END

BEGIN TRANSACTION

	IF @allMoneyForGame - @moneyForAllItems19And21 >= 0
	BEGIN
		
		UPDATE UsersGames
		SET
			Cash = @allMoneyForGame - @moneyForAllItems11And12
		WHERE UserId = @userID 
			  AND GameId = @gameID

		SET @allMoneyForGame = @allMoneyForGame - @moneyForAllItems11And12;

		INSERT INTO UserGameItems (UserGameId, ItemId)
		SELECT @userGameId, items.Id
		FROM (SELECT Id FROM Items WHERE MinLevel BETWEEN 19 AND 21) AS items

		COMMIT
	END

	ELSE
	BEGIN
		ROLLBACK 
	END

SELECT it.Name
FROM UserGameItems AS ugi
JOIN Items AS it
ON ugi.ItemId = it.Id
WHERE UserGameId = @userGameId
ORDER BY it.Name