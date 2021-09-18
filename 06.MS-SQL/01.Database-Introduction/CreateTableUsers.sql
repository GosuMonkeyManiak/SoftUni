Create Table [Users]
(
	[Id] bigint Primary Key Identity(1, 1),
	[Username] varchar(30) unique not null,
	[Password] varchar(26) not null,
	[ProfilePicture] varbinary(Max),
	[LastLoginTime] datetime2,
	[IsDeleted] bit not null
)

Insert Into [Users] ([Username], [Password], [IsDeleted])
Values ('Gos', '12', 1),
	   ('GosuMonkeyManiak', '1234', 0),
	   ('Gosu', '12', 1),
	   ('Nina', '123456', 1),
	   ('Mitko', '0987654321', 0)