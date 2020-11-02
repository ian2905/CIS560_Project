IF OBJECT_ID(N'Trains,Train') IS NULL
BEGIN
   CREATE TABLE Trains.Train
   (
      TrainID INT NOT NULL IDENTITY(1, 1),
      Name NVARCHAR(32) NOT NULL,
      Company NVARCHAR(64) NOT NULL,
      Driver NVARCHAR(32) NOT NULL,
      BaseSpeed INT NOT NULL,
      CarCapcaity INT NOT NULL,
      CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
      UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),

      CONSTRAINT [PK_Trains_Train_TrainID] PRIMARY KEY CLUSTERED
      (
         TrainID ASC
      )
   );
END;

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.key_constraints kc
      WHERE kc.parent_object_id = OBJECT_ID(N'Trains.Train')
         AND kc.[name] = N'UK_Trains_Train_Name'
   )
BEGIN
   ALTER TABLE Trains.Train
   ADD CONSTRAINT [PK_Trains_Train_name] UNIQUE NONCLUSTERED
   (
      Email ASC
   )
END;

/****************************
 * Check Constraints
 ****************************/

