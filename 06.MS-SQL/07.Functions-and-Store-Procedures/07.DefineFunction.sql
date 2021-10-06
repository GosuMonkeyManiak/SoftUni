CREATE FUNCTION udf_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(20))
RETURNS BIT
AS
BEGIN
	DECLARE @i INT = 1

	WHILE(@i <= LEN(@word))
	BEGIN
		
		DECLARE @currentLetter VARCHAR(1) = SUBSTRING(@word, @i, 1);

		IF CHARINDEX(@currentLetter, @setOfLetters) = 0
		BEGIN
			RETURN 0
		END

		SET @i += 1;
	END

	RETURN 1
END

SELECT dbo.udf_IsWordComprised('pppp', 'Guy')