select * from FeedbackStatus

INSERT INTO Locations (Name) VALUES
('Sfax'),
('Monastir'),
('Sousse'),
('Tunis');

SELECT * FROM Contacts
INSERT INTO FeedbackStatuses (Id, Name)
VALUES (1, 'Pending');
INSERT INTO FeedbackStatuses (Id, Name) VALUES (1, 'Pending');
INSERT INTO FeedbackStatuses (Id, Name) VALUES (2, 'Approved');
INSERT INTO FeedbackStatuses (Id, Name) VALUES (3, 'Rejected');
EXEC sp_fkeys 'Feedbacks';
-- Vérifier que la table FeedbackStatuses existe
SELECT * FROM sys.tables WHERE name = 'FeedbackStatuses';

-- Vérifier qu'il y a un statut Pending
SELECT * FROM dbo.FeedbackStatuses;

-- Vérifier les colonnes de Feedbacks
SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Feedbacks';
EXEC sp_help 'dbo.Feedbacks';
SELECT * FROM dbo.Feedbacks;
USE Feedbackdb;
GO
SELECT * FROM sys.tables WHERE name = 'FeedbackStatuses';
SELECT * FROM dbo.Feedbacks;
INSERT INTO dbo.FeedbackStatuses (Name) 
VALUES ('Pending'), ('Approved'), ('Rejected');
USE FeedbackManagementDB;
GO

SELECT * FROM dbo.FeedbackStatuses;
INSERT INTO dbo.FeedbackStatuses (Name)
VALUES ('Approved'), ('Rejected');

SELECT COLUMN_NAME 
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'Feedbacks';

INSERT INTO dbo.Feedbacks (ContactId, StatusId, LocationId, Score, Comment)
VALUES (1, 1, 1, 0, 'Mon feedback test');
SELECT * FROM dbo.FeedbackStatuses;
SELECT Id, LocationId, ContactId, Score, Comment, StatusId
FROM dbo.Feedbacks;
ALTER TABLE dbo.Feedbacks
DROP CONSTRAINT [FK_dbo.Feedback_dbo.FeedbackStatus_StatusId];
ALTER TABLE dbo.Feedbacks
ADD CONSTRAINT [FK_Feedbacks_FeedbackStatuses_StatusId]
FOREIGN KEY (StatusId) REFERENCES dbo.FeedbackStatuses(Id)
ON DELETE NO ACTION;  -- ou ON DELETE RESTRICT

USE Feedbackdb;

CREATE TABLE dbo.FeedbackStatuses (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);
USE FeedbackManagementDB;
INSERT INTO dbo.FeedbackStatuses (Name) VALUES ('Pending');
INSERT INTO dbo.FeedbackStatuses (Name) VALUES ('Approved');
INSERT INTO dbo.FeedbackStatuses (Name) VALUES ('Rejected');
select * from Contacts

