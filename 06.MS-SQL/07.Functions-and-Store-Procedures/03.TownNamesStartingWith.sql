CREATE PROCEDURE usp_GetTownsStartingWith
	@StartingString VARCHAR(20)
AS
BEGIN
	SELECT [Name]
	FROM Towns
	WHERE LEFT([Name], LEN(@StartingString)) = @StartingString
END

EXEC usp_GetTownsStartingWith 'b'