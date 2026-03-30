CREATE TABLE Locations (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Name NVARCHAR(256) NOT NULL
);
INSERT INTO Locations (Name) VALUES
('Sfax'),
('Monastir'),
('Sousse'),
('Tunis');
SELECT * FROM Locations;
USE MyDbContext;
CREATE TABLE dbo.Contacts (
    FirstName NVARCHAR(50),
    LastName NVARCHAR(50),
    Email NVARCHAR(100)
);
SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Contacts' AND TABLE_SCHEMA = 'dbo';
INSERT INTO Contacts (FirstName, LastName, Email) VALUES ('Mohamed', 'Chouayekh', 'mohamedchouayekh4@gmail.com');
SELECT * FROM Contacts;
