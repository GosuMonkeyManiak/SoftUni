Create Table Minions
(
	[Id] int primary key not null identity(1, 1),
	[Name] varchar(50),
	[Age] tinyint
)

Create Table Towns
(
	[Id] int primary key not null identity(1, 1),
	[Name] varchar(50)
)