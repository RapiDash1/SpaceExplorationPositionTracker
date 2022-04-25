CREATE TABLE [dbo].[DeviceInfo]
(
    [Id] BIGINT NOT NULL IDENTITY(1,1),
    [Name] VARCHAR(300) UNIQUE NOT NULL, 
    [Description] VARCHAR(MAX) NOT NULL, 
    [Owner] VARCHAR(100) NULL, 
    [Weight] DECIMAL(13, 5) NULL
)
