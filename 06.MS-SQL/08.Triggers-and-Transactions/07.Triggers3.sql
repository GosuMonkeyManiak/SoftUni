WITH UsersGamesAndItems_CTE(Cash, Price)
AS
(
	SELECT ug.Cash
		  ,it.Price
	FROM Users AS u
	JOIN UsersGames ug
	ON u.Id = ug.UserId
	JOIN UserGameItems AS ugi
	ON ug.Id = ugi.UserGameId
	JOIN Items AS it
	ON ugi.ItemId = it.Id
	WHERE (it.Id BETWEEN 251 AND 299 
		  OR it.Id BETWEEN 501 AND 539)
		  AND u.Username IN ('baleremuda', 'loosenoise', 'inguinalself', 'buildingdeltoid', 'monoxidecos')
)

UPDATE UsersGamesAndItems_CTE
SET 
	Cash -= Price