CREATE TABLE Teachers
(
	TeacherID INT PRIMARY KEY NOT NULL,
	[Name] NVARChAR(50) NOT NULL,
	ManagerID INT FOREIGN KEY REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers(TeacherID, [Name])
VALUES (101, 'John'),
	   (102, 'Maya'),
	   (103, 'Silvia'),
	   (104, 'Ted'),
	   (105, 'Mark'),
	   (106, 'Greta')

UPDATE Teachers
SET ManagerID = 106
WHERE TeacherID IN (102, 103)

UPDATE Teachers
SET ManagerID = 105
WHERE TeacherID = 104


UPDATE Teachers
SET ManagerID = 101
WHERE TeacherID IN (105, 106)