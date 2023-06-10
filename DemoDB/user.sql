CREATE TABLE [dbo].[User]
(
	 [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (MAX) NULL,
    [LastName]  VARCHAR (MAX) NULL,
    [UserName]  VARCHAR (MAX) NOT NULL,
    [Password]  VARCHAR (MAX) NOT NULL
)
