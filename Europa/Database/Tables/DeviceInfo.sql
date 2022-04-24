CREATE TABLE [dbo].[DeviceInfo]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(300) NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    [Owner] VARCHAR(100) NULL, 
    [Weight] DECIMAL(13, 5) NULL
)
