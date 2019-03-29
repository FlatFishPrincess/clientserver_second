CREATE TABLE [dbo].[Students]
(
	[StudentID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [studentFirstName] NVARCHAR(50) NOT NULL, 
    [studentLastName] NVARCHAR(50) NOT NULL, 
    [studentMajor] INT NULL
)
