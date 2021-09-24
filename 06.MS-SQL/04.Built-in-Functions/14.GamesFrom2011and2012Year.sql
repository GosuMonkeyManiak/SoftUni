SELECT TOP(50) [Name]
	  ,FORMAT([Start], 'yyyy-MM-dd', 'bg-BG') AS [Start]
FROM Games
WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start],
		 [Name]