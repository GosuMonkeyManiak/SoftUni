SELECT TOP(5)
	   s.EmployeeID
	  ,s.JobTitle
	  ,s.AddressID
	  ,a.AddressText
FROM Employees AS s
JOIN Addresses AS a
ON s.AddressID = a.AddressID
ORDER BY s.AddressID