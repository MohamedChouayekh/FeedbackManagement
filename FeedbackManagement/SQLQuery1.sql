USE FeedbackManagementDB;
GO
SELECT * FROM dbo.Contacts;
ALTER TABLE dbo.Contacts
DROP COLUMN Password;
USE FeedbackManagementDB;
GO
SELECT Id, Name, Email, Password
FROM dbo.Contacts;
SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Contacts';

