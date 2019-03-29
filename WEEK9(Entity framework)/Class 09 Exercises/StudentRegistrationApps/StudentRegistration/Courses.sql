CREATE TABLE [dbo].[Courses]
(
	[CourseId] INT NOT NULL,
	[CourseDepartmentId] NVARCHAR(10) not null,
	[CourseName] nvarchar(50) not null, 
    CONSTRAINT [FK_Courses_ToDepartment] FOREIGN KEY ([CourseDepartmentId]) REFERENCES [Departments]([DepartmentId]), 
    PRIMARY KEY ([CourseId], [CourseDepartmentId]) 
)