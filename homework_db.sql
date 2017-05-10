USE Master
GO

CREATE DATABASE Homework
GO

USE Homework
GO

CREATE TABLE Users
(
	UserID VARCHAR(256) NOT NULL,
	FirstName VARCHAR(256) NOT NULL,
	LastName VARCHAR(256) NOT NULL,
	EmailAddress VARCHAR(512) NOT NULL,
	JoinedDate DATETIME,
	CONSTRAINT PK_User PRIMARY KEY (UserID)
)
GO

CREATE INDEX idx_user_id ON Users(UserID)
CREATE INDEX idx_user_name ON Users(FirstName, LastName)
GO

INSERT INTO Users VALUES('George', 'George', 'Doe', 'george.doe@email.com', GETDATE())
INSERT INTO Users VALUES('Ash', 'Ash', 'Prasad', 'ash.prasad@email.com', GETDATE())
INSERT INTO Users VALUES('com3773', 'Content Manager', '3773', 'com3773@test.com', GETDATE())
INSERT INTO Users VALUES('admin3773', 'Administrator', '3773', 'admin3773@change.me', GETDATE())
GO


IF OBJECT_ID ( 'GetUserByUserID', 'P' ) IS NOT NULL   
    DROP PROCEDURE GetUserByUserID;  
GO 

CREATE PROC GetUserByUserID
(
	@userID	VARCHAR(256)
)
AS
SELECT	UserID = UserID,
		Name = FirstName + ' ' + LastName,
		EmailAddress = EmailAddress,
		JoinedDate = JoinedDate
FROM	Users
WHERE	UserID = @userID
GO
EXEC GetUserByUserID 'ash'

CREATE VIEW [dbo].[VW_Users] AS
SELECT	UserID = UserID,
		Name = FirstName + ' ' + LastName,
		EmailAddress = EmailAddress,
		JoinedDate = JoinedDate
FROM	Users

GO

SELECT * FROM VW_Users