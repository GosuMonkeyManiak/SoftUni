SELECT c.CountryCode
	  ,m.MountainRange
	  ,p.PeakName
	  ,p.Elevation
FROM MountainsCountries AS mc
JOIN Mountains AS m
ON mc.MountainId = m.Id
JOIN Peaks AS p
ON mc.MountainId = p.MountainId
JOIN Countries AS c
ON mc.CountryCode = c.CountryCode
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC