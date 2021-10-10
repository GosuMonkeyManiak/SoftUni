SELECT [Email Provider]
	  ,COUNT([Email Provider]) AS [Number of Users]
FROM
(
	SELECT *
	  ,SUBSTRING(Email, CHARINDEX('@', Email, 1) + 1, LEN(Email) - CHARINDEX('@', Email, 1)) AS [Email Provider]
	FROM Users
) AS u
GROUP BY [Email Provider]
ORDER BY [Number of Users] DESC
	    ,[Email Provider]
