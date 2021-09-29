SELECT e.EmployeeID
	  ,e.FirstName
	  ,CASE 
			WHEN YEAR(p.StartDate) >= 2005 THEN NULL
			ELSE p.[Name]
	   END AS ProjectName
FROM EmployeesProjects AS ep
JOIN Employees AS e
ON ep.EmployeeID = e.EmployeeID
JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24