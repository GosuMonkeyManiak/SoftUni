CREATE DATABASE [Movies];

CREATE TABLE [Directors]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[DirectorName] NVARCHAR(50) NOT NULL,
	[Notes] NVARCHAR(250)
)

INSERT INTO [Directors] ([DirectorName])
VALUES ('Dimitar Kupanov'),
	   ('Dimitar Chokov'),
	   ('Dimitar Dimitrov'),
	   ('Velizar Dimitrov'),
       ('Dimitar Georgiev')

CREATE TABLE [Genres]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[GenreName] NVARCHAR(15) NOT NULL,
	[Notes] NVARCHAR(250)
)

INSERT INTO [Genres] ([GenreName])
VALUES ('Action'),
	   ('Comedy'),
	   ('Science'),
	   ('Educational'),
       ('Historical')

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[CategoryName] NVARCHAR(25) NOT NULL,
	[Notes] NVARCHAR(250)
)

INSERT INTO [Categories] ([CategoryName])
VALUES ('Cars'),
	   ('Ships'),
	   ('Weapons'),
	   ('Adventure'),
	   ('Hacking')

CREATE TABLE [Movies]
(
	[Id] INT PRIMARY KEY IDENTITY(1, 1),
	[Title] NVARCHAR(20) NOT NULL,
	[DirectorId] INT FOREIGN KEY REFERENCES [Directors]([Id]) NOT NULL,
	[CopyrightYear] DATE NOT NULL,
	[Length] TIME NOT NULL,
	[GenreId] INT FOREIGN KEY REFERENCES [Genres]([Id]) NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[Rating] TINYINT NOT NULL,
	[Notes] NVARCHAR(250)
)

INSERT INTO [Movies] ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating])
VALUES ('Fast and Furious', 1, '2019-05-19', '1:45', 1, 1, 10),
       ('The Terminator', 2, '2008-09-10', '2:20', 2, 2, 5),
	   ('The Terminator 2', 3, '2016-08-25', '1:20', 3, 3, 7),
	   ('Man in Black', 4, '2016-10-12', '1:30', 4, 4, 8),
	   ('Home Alone', 5, '2008-12-19', '2:45', 5, 5, 9)
