SELECT 
	curr.CurrencyCode AS CurrencyCode
   ,curr.Description AS Currency
   ,COUNT(c.CountryName) AS NumberOfCountries
FROM Countries AS c
RIGHT JOIN Currencies AS curr
ON c.CurrencyCode = curr.CurrencyCode
GROUP BY curr.CurrencyCode, curr.Description
ORDER BY NumberOfCountries DESC,
		 Currency