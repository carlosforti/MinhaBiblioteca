-- Create a new database called 'MinhaBiblioteca'
-- Connect to the 'master' database to run this snippet
USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'MinhaBiblioteca'
)
CREATE DATABASE MinhaBiblioteca
GO

USE [MinhaBiblioteca]
GO

ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = OFF
GO

-- Create a new table called '[Editoras]' in schema '[dbo]'
-- Drop the table if it already exists
IF OBJECT_ID('[dbo].[Editoras]', 'U') IS NOT NULL
DROP TABLE [dbo].[Editoras]
GO
-- Create the table in the specified schema
CREATE TABLE [dbo].[Editoras]
(
    [Id] INT IDENTITY NOT NULL, -- Primary Key column
    [Nome] NVARCHAR(200) NOT NULL,
    [Email] NVARCHAR(200),
    [Pais] NVARCHAR(200),
    CONSTRAINT PK_Editoras PRIMARY KEY(Id)
);
GO