WITH HigestPeak (CountryName, PeakName, Elevation, MountainRange, PeakRanK)
AS
(
	SELECT 
		   c.CountryName
		  ,p.PeakName
		  ,p.Elevation
		  ,m.MountainRange
		  ,DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY p.Elevation DESC) AS PeakRanK
	FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc
	ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m
	ON mc.MountainId = m.Id
	LEFT JOIN Peaks AS p
	ON m.Id = p.MountainId
)

SELECT
	   TOP(5) 
	   CountryName AS Country
	  ,CASE 
			WHEN PeakName IS NULL THEN '(no highest peak)'
			ELSE PeakName
	   END AS [HighestPeakName]
	  ,CASE
			WHEN Elevation IS NULL THEN '0'
			ELSE Elevation
	   END AS [HighestPeakElevation]
	  ,CASE
			WHEN MountainRange IS NULL THEN '(no mountain)'
			ELSE MountainRange
	   END AS Mountain
FROM HigestPeak
WHERE PeakRanK = 1
ORDER BY CountryName
		,PeakName