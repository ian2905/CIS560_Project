IF OBJECT_ID(N'Trains.Car') IS NULL
BEGIN
   CREATE TABLE Train.Car
   (
      CarId INT NOT NULL IDENTITY(1, 1),
      TrainID INT NOT NULL,
      CarTypeID INT NOT NULL,
      TicketPrice INT NOT NULL,
      PassengerCapacity INT NOT NULL,
      CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
      UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),

      CONSTRAINT [PK_Trains_Train_CarID] PRIMARY KEY CLUSTERED
      (
         CarID ASC
      ),

      CONSTRAINT FK_Trains_Car_Trains_Train FOREIGN KEY(TrainID)
      REFERENCES Trains.Train(TrainID),

      CONSTRAINT FK_Trains_Car_Trains_CarType FOREIGN KEY(CarTypeID)
      REFERENCES Trains.CarType(CarTypeID)
   );
END;

/****************************
 * Unique Constraints
 ****************************/

 /****************************
 * Foreign Keys Constraints
 ****************************/

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Trains.Car')
         AND fk.referenced_object_id = OBJECT_ID(N'Trains.Train')
         AND fk.[name] = N'FK_Trains_Car_Trains_Train'
   )
BEGIN
   ALTER TABLE Train.Car
   ADD CONSTRAINT [FK_Trains_Car_Trains_Train] FOREIGN KEY
   (
      TrainID
   )
   REFERENCES Trains.Train
   (
      TrainID
   );
END;

IF NOT EXISTS
   (
      SELECT *
      FROM sys.foreign_keys fk
      WHERE fk.parent_object_id = OBJECT_ID(N'Trains.Car')
         AND fk.referenced_object_id = OBJECT_ID(N'Trains.CarType')
         AND fk.[name] = N'FK_Trains_Car_Trains_CarType'
   )
BEGIN
   ALTER TABLE Trains.Car
   ADD CONSTRAINT [FK_Trains_Car_Trains_CarType] FOREIGN KEY
   (
      CarTypeID
   )
   REFERENCES Trains.CarType
   (
      CarTypeID
   );
END;



/****************************
 * Check Constraints
 ****************************/


