WITH UsersAndGames_CTE (Username, GameName, Cash)
AS
(
	SELECT u.Username
		  ,g.[Name]
		  ,ug.Cash
	FROM Users AS u
	JOIN UsersGames AS ug
	ON u.Id = ug.UserId
	JOIN Games AS g
	ON ug.GameId = g.Id
)



UPDATE UsersAndGames_CTE
SET
	Cash += 50000
WHERE Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
	  AND GameName = 'Bali'