CREATE PROCEDURE usp_BuyItemForUser
	@username NVARCHAR(50)
   ,@game NVARCHAR(50)
   ,@itemName NVARCHAR(50)
AS
BEGIN
	DECLARE @gameId INT = (SELECT Id FROM Games WHERE [Name] = @game)
	DECLARE @userId INT = (SELECT Id FROM Users WHERE Username = @username)
	DECLARE @userGameId INT = (SELECT Id FROM UsersGames WHERE UserId = @userId AND GameId = @gameId)

	DECLARE @itemPrice MONEY = (SELECT Price FROM Items WHERE [Name] = @itemName)
	DECLARE @itemId INT = (SELECT Id FROM Items WHERE [Name] = @itemName)

	UPDATE UsersGames
	SET
		Cash -= @itemPrice
	WHERE GameId = @gameId
		  AND UserId = @userId

	INSERT INTO UserGameItems (UserGameId, ItemId)
	VALUES (@userGameId, @itemId)
END

EXEC usp_BuyItemForUser 'Alex', 'Edinburgh', 'Blackguard'
EXEC usp_BuyItemForUser 'Alex', 'Edinburgh', 'Bottomless Potion of Amplification'
EXEC usp_BuyItemForUser 'Alex', 'Edinburgh', 'Eye of Etlich (Diablo III)'
EXEC usp_BuyItemForUser 'Alex', 'Edinburgh', 'Gem of Efficacious Toxin'
EXEC usp_BuyItemForUser 'Alex', 'Edinburgh', 'Golden Gorget of Leoric'
EXEC usp_BuyItemForUser 'Alex', 'Edinburgh', 'Hellfire Amulet'

SELECT u.Username
	  ,g.[Name]
	  ,CONCAT(REPLICATE('*', CHARINDEX('.', ug.Cash, 1) - 1), '.', REPLICATE('*', LEN(ug.cash) - CHARINDEX('.', ug.Cash, 1))) AS Cash
	  ,i.[Name]
FROM UsersGames AS ug
JOIN Users AS u
ON u.Id = ug.UserId
JOIN Games AS g
ON g.Id = ug.GameId
JOIN UserGameItems AS ugi
ON ugi.UserGameId = ug.Id
JOIN Items AS i
ON i.Id = ugi.ItemId
WHERE g.Id = 221
ORDER BY i.[Name]