CREATE TABLE Students
(
	StudentID INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
)

CREATE TABLE Exams
(
	ExamID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE StudentsExams
(
	StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID),
	CONSTRAINT PK_StudentsExams PRIMARY KEY (StudentID, ExamID)
)

INSERT INTO Students([Name])
VALUES ('Mila'),
	   ('Toni'),
	   ('Ron')

INSERT INTO Exams(ExamID, [Name])
VALUES (101, 'SpringMVC'),
       (102, 'Neo4j'),
	   (103, 'Oracle 11g')

INSERT INTO StudentsExams(StudentID, ExamID)
VALUES (1, 101),
	   (1, 102),
	   (2, 101),
	   (3, 103),
	   (2, 102),
	   (2, 103)