CREATE TABLE [dbo].[Departments]
(
	[DepartmentId] nvarchar(10) not null,
	[DepartmentName] nvarchar(50) not null, 
    CONSTRAINT [PK_Departments] PRIMARY KEY ([DepartmentId])
)