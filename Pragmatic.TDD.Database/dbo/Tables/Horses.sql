CREATE TABLE [dbo].[Horses]
(
	[Id] INT NOT NULL IDENTITY(1,1), 
    [Name] NVARCHAR(50) NOT NULL,
	[ColorId] TINYINT NOT NULL,
	[SireId] INT NULL,
	[DamId] INT NULL,
	[RaceStarts] INT NOT NULL,
	[RaceWins] INT NOT NULL,
	[RacePlace] INT NOT NULL,
	[RaceShow] INT NOT NULL,
	[Earnings] INT NOT NULL,
	CONSTRAINT [FK_Horses_Color] FOREIGN KEY ([ColorId]) REFERENCES [Colors]([Id]), 
    CONSTRAINT [FK_Horses_Sire] FOREIGN KEY ([SireId]) REFERENCES [Horses]([Id]),
    CONSTRAINT [FK_Horses_Dam] FOREIGN KEY ([DamId]) REFERENCES [Horses]([Id]), 
	CONSTRAINT [PK_Horses] PRIMARY KEY ([Id])
)
