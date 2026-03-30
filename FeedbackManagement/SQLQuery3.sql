-- Create a new table with Id as Identity
CREATE TABLE dbo.User_New
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(256) NOT NULL,
    Email NVARCHAR(256) NOT NULL,
    Password NVARCHAR(MAX) NOT NULL
);

-- Copy data from the old table (exclude Id if it has existing values)
INSERT INTO dbo.User_New (Name, Email, Password)
SELECT Name, Email, Password FROM dbo.[User];

-- Drop the old table
DROP TABLE dbo.[User];

-- Rename the new table to the original name
EXEC sp_rename 'dbo.User_New', 'User';