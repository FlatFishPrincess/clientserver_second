CREATE TABLE [dbo].[Students]
(
	[StudentId] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	[StudentFirstName] nvarchar(50) not null,
	[StudentLastName] nvarchar(50) not null, 
    [StudentMajor] NVARCHAR(10) NULL, 
)