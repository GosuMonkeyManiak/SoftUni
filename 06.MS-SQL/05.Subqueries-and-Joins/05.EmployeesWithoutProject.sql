SELECT TOP(3)
	   s.EmployeeID
	  ,s.FirstName
FROM EmployeesProjects AS ep
RIGHT JOIN Employees AS s
ON ep.EmployeeID = s.EmployeeID
WHERE ep.EmployeeID IS NULL
ORDER BY s.EmployeeID