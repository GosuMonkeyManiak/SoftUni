WITH CTE_CustomQuery(Username, Game, Character, Strength, Defence, Speed, Mind, Luck)
AS
(
	SELECT u.Username
		  ,g.[Name] AS Game
		  ,MAX(c.[Name]) AS Character
		  ,SUM(ist.Strength) + MAX(gst.Strength) + MAX(cst.Strength) AS Strength
		  ,SUM(ist.Defence) + MAX(gst.Defence) + MAX(cst.Defence) AS Defence
		  ,SUM(ist.Speed) + MAX(gst.Speed) + MAX(cst.Speed) AS Speed
		  ,SUM(ist.Mind) + MAX(gst.Mind) + MAX(cst.Mind) AS Mind
		  ,SUM(ist.Luck) + MAX(gst.Luck) + MAX(cst.Luck) AS Luck
	FROM Users AS u
	JOIN UsersGames AS ug
	ON u.Id = ug.UserId
	JOIN Games AS g
	ON ug.GameId = g.Id
	JOIN GameTypes AS gt
	ON g.GameTypeId = gt.Id
	JOIN [Statistics] gst
	ON gt.BonusStatsId = gst.Id
	JOIN Characters AS c
	ON ug.CharacterId = c.Id
	JOIN [Statistics] AS cst
	ON c.StatisticId = cst.Id
	JOIN UserGameItems AS ugi
	ON ug.Id = ugi.UserGameId
	JOIN Items AS it
	ON ugi.ItemId = it.Id
	JOIN [Statistics] AS ist
	ON it.StatisticId = ist.Id
	GROUP BY g.[Name], u.Username
)

SELECT *
FROM CTE_CustomQuery
ORDER BY Strength DESC,
	     Defence DESC,
		 Speed DESC,
		 Mind DESC,
		 Luck DESC