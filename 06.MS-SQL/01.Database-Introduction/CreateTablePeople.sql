Create Table People
(
	[Id] int Primary Key Identity(1, 1),
	[Name] nchar(200) not null,
	[Picture] varbinary(Max),
	[Height] decimal(18, 2),
	[Weight] decimal(18, 2),
	[Gender] char(1) not null,
	[Birthdate] datetime2 not null,
	[Biography] nvarchar(MAX)
)

Insert Into [People] ([Name], [Gender], [Birthdate])
Values ('Dimitar Kupanov', 'm', '1948-08-10'),
       ('Ivan Grigorov', 'm', '1948-08-10'),
	   ('Nina Kupanova', 'f', '1948-08-10'),
	   ('Nina Grigorova', 'f', '1948-08-10'),
	   ('Dimitar Kupanov', 'm', '1948-08-10')