CREATE TABLE [dbo].[Task]
(
	[Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [Description] VARCHAR(MAX) NULL, 
    [Status] VARCHAR(MAX) NULL, 
    [CreatedOn] VARCHAR(MAX) NULL
)
