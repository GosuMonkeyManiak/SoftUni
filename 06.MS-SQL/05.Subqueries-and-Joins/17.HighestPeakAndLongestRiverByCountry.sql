WITH HighestRiverAndPeak(CountryName, HighestPeakElevation, LongestRiverLength, PeakRank, RiverRank)
AS
(
	SELECT c.CountryName
		  ,p.Elevation AS HighestPeakElevation
		  ,r.[Length] AS LongestRiverLength
		  ,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRank
		  ,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY r.[Length] DESC) AS RiverRank
	FROM MountainsCountries AS mc
	JOIN Mountains AS m
	ON mc.MountainId = m.Id
	JOIN Peaks AS p
	ON m.Id = p.MountainId
	JOIN Countries AS c
	ON mc.CountryCode = c.CountryCode
	JOIN CountriesRivers AS cr
	ON cr.CountryCode = mc.CountryCode
	JOIN Rivers AS r
	ON cr.RiverId = r.Id
)

SELECT TOP(5)
	   CountryName
	  ,HighestPeakElevation
	  ,LongestRiverLength
FROM HighestRiverAndPeak
WHERE PeakRank = 1 AND RiverRank = 1
ORDER BY HighestPeakElevation DESC,
		 LongestRiverLength DESC