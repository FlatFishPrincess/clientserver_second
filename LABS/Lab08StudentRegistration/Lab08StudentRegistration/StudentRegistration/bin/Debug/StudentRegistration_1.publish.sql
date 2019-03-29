﻿/*
Deployment script for StudentRegistration

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "StudentRegistration"
:setvar DefaultFilePrefix "StudentRegistration"
:setvar DefaultDataPath "C:\Users\mhrybyk\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"
:setvar DefaultLogPath "C:\Users\mhrybyk\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The column [dbo].[Courses].[CourseNumber] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Courses])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[Departments].[DepartmentCode] is being dropped, data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[Departments])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Starting rebuilding table [dbo].[Courses]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Courses] (
    [CourseId]           INT           NOT NULL,
    [CourseDepartmentId] NVARCHAR (10) NOT NULL,
    [CourseName]         NVARCHAR (50) NOT NULL,
    PRIMARY KEY CLUSTERED ([CourseId] ASC, [CourseDepartmentId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Courses])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Courses] ([CourseId], [CourseDepartmentId], [CourseName])
        SELECT   [CourseId],
                 [CourseDepartmentId],
                 [CourseName]
        FROM     [dbo].[Courses]
        ORDER BY [CourseId] ASC, [CourseDepartmentId] ASC;
    END

DROP TABLE [dbo].[Courses];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Courses]', N'Courses';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[Departments]...';


GO
BEGIN TRANSACTION;

SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

CREATE TABLE [dbo].[tmp_ms_xx_Departments] (
    [DepartmentId]   NVARCHAR (10) NOT NULL,
    [DepartmentName] NVARCHAR (50) NOT NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_Departments1] PRIMARY KEY CLUSTERED ([DepartmentId] ASC)
);

IF EXISTS (SELECT TOP 1 1 
           FROM   [dbo].[Departments])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_Departments] ([DepartmentId], [DepartmentName])
        SELECT   [DepartmentId],
                 [DepartmentName]
        FROM     [dbo].[Departments]
        ORDER BY [DepartmentId] ASC;
    END

DROP TABLE [dbo].[Departments];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_Departments]', N'Departments';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_Departments1]', N'PK_Departments', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [dbo].[Students]...';


GO
ALTER TABLE [dbo].[Students] ALTER COLUMN [StudentMajor] NVARCHAR (10) NULL;


GO
PRINT N'Creating [dbo].[Registration]...';


GO
CREATE TABLE [dbo].[Registration] (
    [StudentId]    INT           NOT NULL,
    [CourseId]     INT           NOT NULL,
    [DepartmentId] NVARCHAR (10) NOT NULL,
    PRIMARY KEY CLUSTERED ([DepartmentId] ASC, [StudentId] ASC, [CourseId] ASC)
);


GO
PRINT N'Creating [dbo].[FK_Courses_ToDepartment]...';


GO
ALTER TABLE [dbo].[Courses] WITH NOCHECK
    ADD CONSTRAINT [FK_Courses_ToDepartment] FOREIGN KEY ([CourseDepartmentId]) REFERENCES [dbo].[Departments] ([DepartmentId]);


GO
PRINT N'Creating [dbo].[FK_Registration_ToStudents]...';


GO
ALTER TABLE [dbo].[Registration] WITH NOCHECK
    ADD CONSTRAINT [FK_Registration_ToStudents] FOREIGN KEY ([StudentId]) REFERENCES [dbo].[Students] ([StudentId]);


GO
PRINT N'Creating [dbo].[FK_Registration_ToCourses]...';


GO
ALTER TABLE [dbo].[Registration] WITH NOCHECK
    ADD CONSTRAINT [FK_Registration_ToCourses] FOREIGN KEY ([CourseId], [DepartmentId]) REFERENCES [dbo].[Courses] ([CourseId], [CourseDepartmentId]);


GO
PRINT N'Checking existing data against newly created constraints';


GO
USE [$(DatabaseName)];


GO
ALTER TABLE [dbo].[Courses] WITH CHECK CHECK CONSTRAINT [FK_Courses_ToDepartment];

ALTER TABLE [dbo].[Registration] WITH CHECK CHECK CONSTRAINT [FK_Registration_ToStudents];

ALTER TABLE [dbo].[Registration] WITH CHECK CHECK CONSTRAINT [FK_Registration_ToCourses];


GO
PRINT N'Update complete.';


GO
