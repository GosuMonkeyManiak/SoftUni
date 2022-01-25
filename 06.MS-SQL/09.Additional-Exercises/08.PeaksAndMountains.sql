SELECT p.PeakName
	  ,m.MountainRange AS Mountain
	  ,p.Elevation
FROM Peaks as p
JOIN Mountains as m
ON p.MountainId = m.Id
ORDER BY p.Elevation DESC, p.PeakName