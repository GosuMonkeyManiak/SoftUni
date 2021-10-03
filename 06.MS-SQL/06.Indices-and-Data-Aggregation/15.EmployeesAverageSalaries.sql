SELECT *
INTO EmployeeAS
FROM Employees
WHERE Salary > 30000

DELETE EmployeeAS
WHERE ManagerID = 42

UPDATE EmployeeAS
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary) AS AverageSalary
FROM EmployeeAS
GROUP BY DepartmentID