SELECT m.EmployeeID
	  ,m.FirstName
	  ,m.ManagerID
	  ,s.FirstName AS [ManagerName]
FROM Employees AS s
JOIN Employees AS m
ON s.EmployeeID = m.ManagerID
WHERE m.ManagerID IN (3, 7)
ORDER BY m.EmployeeID