SELECT u.Username
	  ,g.[Name] AS [Game Name]
	  ,COUNT(i.[Name]) AS [Items Count]
	  ,SUM(i.Price) AS [Items Price]
FROM Users AS u
JOIN UsersGames AS ug
ON u.Id = ug.UserId
JOIN Games AS g
ON ug.GameId = g.Id
JOIN UserGameItems AS ugi
ON ug.Id = ugi.UserGameId
JOIN Items AS i
ON ugi.ItemId = i.Id
GROUP BY g.[Name], u.Username
HAVING COUNT(i.[Name]) >= 10
ORDER BY COUNT(i.[Name]) DESC,
		 SUM(i.Price) DESC,
		 u.Username