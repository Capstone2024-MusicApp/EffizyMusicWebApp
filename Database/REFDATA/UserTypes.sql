-- Insert data into UserTypes table

SET IDENTITY_INSERT UserTypes ON;

INSERT INTO UserTypes (UserTypeID, Description, UserID)
VALUES (1, 'Administator', null);
GO

INSERT INTO UserTypes (UserTypeID, Description, UserID)
VALUES (2, 'Instructor', null);
GO

INSERT INTO UserTypes (UserTypeID, Description, UserID)
VALUES (3, 'Student', null);
GO


SET IDENTITY_INSERT UserTypes OFF;
