﻿/*
Deployment script for WeightsDB

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "WeightsDB"
:setvar DefaultFilePrefix "WeightsDB"
:setvar DefaultDataPath "C:\Users\lukis\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\lukis\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

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
PRINT N'Creating Procedure [dbo].[sp_NewPerson]...';


GO
CREATE PROCEDURE [dbo].[sp_NewPerson]
	@Id int,
	@Name nvarchar(50),
	@Age int,
	@Height int
AS
	INSERT INTO Persons VALUES (@Id, @Name, @Age, @Height);
RETURN 0
GO
PRINT N'Creating Procedure [dbo].[sp_NewWeight]...';


GO
CREATE PROCEDURE [dbo].[sp_NewWeight]
	@PersonId int,
	@Id int,
	@Weight float,
	@DateWhenAdd Date
AS
	INSERT INTO Weights VALUES (@PersonId, @Id, @Weight, @DateWhenAdd);
RETURN 0
GO
PRINT N'Update complete.';


GO
