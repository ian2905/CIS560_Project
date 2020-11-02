DECLARE @CarTypeStaging TABLE
(
	CarTypeID TINYINT NOT NULL PRIMARY KEY,
	[Name] VARCHAR(32) NOT NULL UNIQUE
);

/***************************** Modify values here *****************************/

INSERT @CarTypeStaging(CarTypeId, [Name])
VALUES
	(1, 'FirstClass'),
	(2, 'Business'),
	(3, 'Economy');

/******************************************************************************/

MERGE Trains.CarType T
USING @CarTypeStaging S ON S.CarTypeID = T.CarTypeID
WHEN MATCHED AND S.[Name] <> T.[Name] THEN
	UPDATE
	SET [Name] = S.[Name]
WHEN NOT MATCHED THEN
	INSERT(CarTypeID, [Name])
	VALUES(S.CarTypeID, S.[Name]);
