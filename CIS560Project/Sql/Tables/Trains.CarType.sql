IF OBJECT_ID(N'Trains.CarType') IS NULL
BEGIN
   CREATE TABLE Trains.CarType
   (
      CarTypeID TINYINT NOT NULL,
      [Name] VARCHAR(32) NOT NULL,

      CONSTRAINT PK_Trains_CarType_CarTypeID PRIMARY KEY CLUSTERED
      (
         CarTypeID ASC
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
      WHERE kc.parent_object_id = OBJECT_ID(N'Trains.CarType')
         AND kc.[name] = N'UK_Trains_CarType_Name'
   )
BEGIN
   ALTER TABLE Trains.CarType
   ADD CONSTRAINT [UK_Trains_CarType_Name] UNIQUE NONCLUSTERED
   (
      [Name]
   )
END;
