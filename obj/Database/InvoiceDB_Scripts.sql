-- 1. Create the Database
CREATE DATABASE InvoiceDB;
GO

USE InvoiceDB;
GO

-- 2. Create Users Table
CREATE TABLE Users (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(100),
    Email NVARCHAR(100) UNIQUE,
    PasswordHash NVARCHAR(MAX),
    Role NVARCHAR(20), -- Admin / User
    CreatedAt DATETIME DEFAULT GETDATE()
);
GO

-- 3. Create Invoices Table
CREATE TABLE Invoices (
    InvoiceId INT PRIMARY KEY IDENTITY(1,1),
    InvoiceNumber NVARCHAR(50),
    CustomerName NVARCHAR(100),
    Amount DECIMAL(18, 2),
    Status NVARCHAR(20), -- Draft, Paid, Cancelled
    CreatedDate DATETIME DEFAULT GETDATE()
);
GO