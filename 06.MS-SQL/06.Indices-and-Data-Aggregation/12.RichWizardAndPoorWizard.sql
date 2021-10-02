SELECT SUM(a.[Difference])
FROM
(
	SELECT DepositAmount, (LAG(DepositAmount, 1, 0) OVER (ORDER BY Id) - LEAD(DepositAmount, 1, 0) OVER (ORDER BY Id)) AS [Difference]
	FROM WizzardDeposits
) AS a