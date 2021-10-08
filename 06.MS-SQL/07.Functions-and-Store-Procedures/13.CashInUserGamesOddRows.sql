CREATE FUNCTION ufn_CashInUsersGames(@gameName NVARCHAR(120))
RETURNS TABLE
AS
RETURN SELECT SUM(cashByGames.Cash) AS SumCash
	   FROM 
	   (
		   SELECT g.[Name]
				 ,ug.Cash
				 ,ROW_NUMBER() OVER (ORDER BY ug.Cash DESC) AS RowNumber
		   FROM Games AS g
		   JOIN UsersGames AS ug
		   ON g.Id = ug.GameId
		   WHERE g.[Name] = @gameName
	   ) AS cashByGames
	   WHERE RowNumber % 2 != 0