SELECT
	p.PeakName
   ,m.MountainRange as Mountain
   ,c.CountryName
   ,con.ContinentName
FROM Peaks as p
JOIN Mountains as m
ON p.MountainId = m.Id
JOIN MountainsCountries as mc
ON m.Id = mc.MountainId
JOIN Countries as c
ON mc.CountryCode = c.CountryCode
JOIN Continents as con
ON c.ContinentCode = con.ContinentCode
ORDER BY p.PeakName, c.CountryName
