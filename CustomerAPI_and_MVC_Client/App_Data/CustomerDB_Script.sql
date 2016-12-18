CREATE DATABASE [Customer]
GO

Use Customer 
GO

CREATE TABLE Customer
(
ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
FirstName varchar(15) NOT NULL,
LastName varchar(15) NOT NULL,
Address_Line1 varchar(100) NOT NULL,
City varchar(30) NOT NULL,
County varchar(50) NOT NULL,
Post_Code varchar (15) NOT NULL,
Telephone varchar (15) NOT NULL,
Email varchar (50) NOT NULL
)
INSERT INTO Customer (FirstName, LastName, Address_Line1, City, County, Post_Code, Telephone, Email)
VALUES ('Jhon','Smith','87 Alxander Street','Birmingham','West Midlands','B27 0LR', '07895634128', 'jhonsmith@hotmail.com'),
('Majid','Najib','86 Grange Road','Birmingham','West Midlands','B14 7RJ', '07895634128', 'mnajib@hotmail.com'),
('Alex','Smith','87 Moore Street','Bradford','West Yorkshire','B27 0LR', '07895634128', 'asmith@hotmail.com'),
('Paul','Smith','87 Alxander Street','London','Greater London','E27 0LR', '07895634128', 'paulsmith@hotmail.com')