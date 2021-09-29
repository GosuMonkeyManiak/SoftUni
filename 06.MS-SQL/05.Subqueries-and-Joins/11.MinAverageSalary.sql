WITH AverageSalaryByDepartments_CTE (Salary)
AS 
(
	SELECT AVG(e.Salary)
	FROM Employees AS e
	JOIN Departments AS d
	ON e.DepartmentID = d.DepartmentID
	GROUP BY e.DepartmentID
)

SELECT MIN(Salary) 
FROM AverageSalaryByDepartments_CTE