-- Insert data into Instruments table

SET IDENTITY_INSERT Instruments ON;


INSERT INTO Instruments (InstrumentID, InstrumentType)
VALUES (1, 'Drums');
GO

INSERT INTO Instruments (InstrumentID, InstrumentType)
VALUES (2, 'Guitar');
GO

INSERT INTO Instruments (InstrumentID, InstrumentType)
VALUES (3, 'Violin');
GO

SET IDENTITY_INSERT Instruments OFF;
