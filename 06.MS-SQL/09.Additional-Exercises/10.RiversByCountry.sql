SELECT 
	c.CountryName
   ,con.ContinentName
   ,CASE
		WHEN COUNT(r.RiverName) = 0 THEN 0
		ELSE COUNT(r.RiverName)
	END AS RiversCount
   ,ISNULL(SUM(r.Length), 0) AS TotalLength
FROM Countries as c
JOIN Continents as con
ON c.ContinentCode = con.ContinentCode
LEFT JOIN CountriesRivers as cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers as r
ON cr.RiverId = r.Id
GROUP BY c.CountryName, con.ContinentName
ORDER BY RiversCount DESC, 
		 TotalLength DESC,
		 CountryName