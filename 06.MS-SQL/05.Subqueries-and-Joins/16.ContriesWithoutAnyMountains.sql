SELECT COUNT(c.CountryCode) AS [Count]
FROM MountainsCountries AS mc
RIGHT JOIN Countries AS c
ON mc.CountryCode = c.CountryCode
WHERE mc.CountryCode IS NULL