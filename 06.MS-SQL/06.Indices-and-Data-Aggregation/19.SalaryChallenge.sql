SELECT TOP(10)
	   em.FirstName
	  ,em.LastName
	  ,em.DepartmentID
FROM
(
	SELECT DepartmentID, AVG(Salary) AS AVGSalary
	FROM Employees
	GROUP BY DepartmentID
) AS e
JOIN Employees AS em
ON e.DepartmentID = em.DepartmentID
WHERE Salary > AVGSalary AND e.DepartmentID = em.DepartmentID
ORDER BY DepartmentID