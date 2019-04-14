CREATE TABLE [dbo].[Registration]
(
    [StudentId] INT NOT NULL, 
    [CourseId] INT NOT NULL, 
    [DepartmentId] NVARCHAR(10) NOT NULL, 
    CONSTRAINT [FK_Registration_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [Students]([StudentId]), 
    CONSTRAINT [FK_Registration_ToCourses] FOREIGN KEY ([CourseId],[DepartmentId]) REFERENCES [Courses]([CourseId],[CourseDepartmentId]), 
    PRIMARY KEY ([DepartmentId], [StudentId], [CourseId])
)