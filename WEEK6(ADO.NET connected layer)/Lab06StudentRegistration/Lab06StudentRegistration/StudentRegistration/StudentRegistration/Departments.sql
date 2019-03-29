CREATE TABLE [dbo].[Departments]
(
	[DepartmentId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [DepartmentCode] NVARCHAR(10) NOT NULL, 
    [DepartmentName] NVARCHAR(50) NOT NULL
)
