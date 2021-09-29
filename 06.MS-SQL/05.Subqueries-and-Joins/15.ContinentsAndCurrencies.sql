WITH ContinentsAndCurrencies(ContinentCode, CurrencyCode, CurrencyUsage, [Rank])
AS
(
	SELECT con.ContinentCode AS ContinentCode
		  ,c.CurrencyCode AS CurrencyCode
		  ,COUNT(c.CurrencyCode) AS CurrencyUsage
		  ,DENSE_RANK() OVER (PARTITION BY con.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [Rank]
	FROM Continents AS con
	JOIN Countries AS c
	ON con.ContinentCode = c.ContinentCode
	GROUP BY con.ContinentCode, c.CurrencyCode
	HAVING COUNT(c.CurrencyCode) > 1
)

SELECT cc.ContinentCode
	  ,cc.CurrencyCode
	  ,cc.CurrencyUsage
FROM Continents AS c
JOIN ContinentsAndCurrencies cc
ON c.ContinentCode = cc.ContinentCode
WHERE [Rank] = 1