CREATE FUNCTION udf_CalculateFutureValue(@initialSum DECIMAL, @yearlyInterestRate FLOAT, @numberOfYears INT)
RETURNS DECIMAL(18, 4)
AS
BEGIN
	DECLARE @result DECIMAL(18, 4)

	SET @result = @initialSum * (POWER((1 + @yearlyInterestRate), @numberOfYears))

	RETURN @result
END

SELECT dbo.udf_CalcualteFutureValue(1000, 0.1, 5)