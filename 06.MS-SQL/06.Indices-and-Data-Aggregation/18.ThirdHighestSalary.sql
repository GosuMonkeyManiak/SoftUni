SELECT DepartmentID, MIN(Salary) AS ThirdHighestSalary
FROM
(
	SELECT EmployeeID
		  ,FirstName
		  ,LastName
		  ,MiddleName
		  ,JobTitle
		  ,DepartmentID
		  ,ManagerID
		  ,HireDate
		  ,Salary
		  ,AddressID
		  ,DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Rank]
	  FROM Employees
) AS e
WHERE [Rank] = 3
GROUP BY DepartmentID