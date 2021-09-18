Alter Table [Minions]
Add [TownId] int 
Constraint FK_Miniosn_Towns Foreign key (TownId)
References [Towns](Id)
