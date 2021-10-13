WITH CTE_AvgMindLuckSpeed(AvgMind, AvgLuck, AvgSpeed)
AS
(
	SELECT (SUM(st.Mind) / COUNT(i.Id)) AS AvgMind
		,(SUM(st.Luck) / COUNT(i.Id)) AS AvgLuck
		,(SUM(st.Speed) / COUNT(i.Id)) AS AvgSpeed
	FROM Items AS i
	JOIN [Statistics] AS st
	ON i.StatisticId = st.Id
)

SELECT i.[Name]
	  ,i.Price
	  ,i.MinLevel
	  ,st.Strength
	  ,st.Defence
	  ,st.Speed
	  ,st.Luck
	  ,st.Mind
FROM Items AS i
JOIN [Statistics] AS st
ON i.StatisticId = st.Id
WHERE st.Mind > (SELECT AvgMind FROM CTE_AvgMindLuckSpeed)
	  AND st.Luck > (SELECT AvgLuck FROM CTE_AvgMindLuckSpeed)
	  AND st.Speed > (SELECT AvgSpeed FROM CTE_AvgMindLuckSpeed)
ORDER BY i.[Name]