SELECT u.Username
	  ,g.[Name] AS [Game Name]
	  ,ug.Cash
	  ,it.[Name] AS [Item Name]
FROM Users AS u
JOIN UsersGames ug
ON u.Id = ug.UserId
JOIN UserGameItems AS ugi
ON ug.Id = ugi.UserGameId
JOIN Items AS it
ON ugi.ItemId = it.Id
JOIN Games AS g
ON ug.GameId = g.Id
WHERE g.[Name] = 'Bali'
ORDER BY u.Username
	    ,it.[Name]