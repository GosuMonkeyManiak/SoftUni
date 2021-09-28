SELECT TOP(50)
	   s.FirstName
	  ,s.LastName
	  ,t.[Name] AS [Town]
	  ,a.AddressText
FROM Employees AS s
JOIN Addresses AS a
ON s.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY s.FirstName
		,s.LastName