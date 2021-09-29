WITH MountainRanges(MountainRange, CountryCode)
AS
(
	SELECT COUNT(m.MountainRange)
		  ,MIN(c.CountryCode)
	FROM MountainsCountries AS mc
	JOIN Countries AS c
	ON mc.CountryCode = c.CountryCode
	JOIN Mountains AS m
	ON mc.MountainId = m.Id
	GROUP BY c.CountryCode
)

SELECT CountryCode, MountainRange
FROM MountainRanges
WHERE CountryCode IN ('BG', 'US', 'RU')