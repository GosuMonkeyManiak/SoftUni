SELECT 
	con.ContinentName
   ,SUM(CAST(c.AreaInSqKm AS BIGINT)) AS CountriesArea
   ,SUM(CAST(c.Population AS bigint)) AS CountriesPopulation
FROM Continents AS con
LEFT JOIN Countries AS c
ON con.ContinentCode = c.ContinentCode
GROUP BY con.ContinentName
ORDER BY CountriesPopulation DESC