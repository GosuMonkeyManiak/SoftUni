CREATE TRIGGER tr_AddaItemToaUser
ON UserGameItems 
INSTEAD OF INSERT
AS
BEGIN
	
	DECLARE @userLevel INT = 
	(
		SELECT ug.Level
		FROM inserted AS i
		JOIN UsersGames AS ug
		ON i.UserGameId = ug.Id
		JOIN Items AS it
		ON i.ItemId = it.Id
	)

	DECLARE @itemLevel INT =
	(
		SELECT it.MinLevel
		FROM inserted AS i
		JOIN UsersGames AS ug
		ON i.UserGameId = ug.Id
		JOIN Items AS it
		ON i.ItemId = it.Id
	)
	
	IF @itemLevel > @userLevel
	BEGIN;
		THROW 50001, 'Item level has to be lower level than user level', 1;
	END

	INSERT INTO UserGameItems (ItemId, UserGameId)
	SELECT *
	FROM inserted
END

GO

INSERT INTO UserGameItems (ItemId, UserGameId)
VALUES (6, 1)