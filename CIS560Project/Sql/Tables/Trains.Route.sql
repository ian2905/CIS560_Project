IF OBJECT_ID(N'Trains.Route') IS NULL
BEGIN
    CREATE TABLE Trains.[Route]
    (
        RouteID INT NOT NULL IDENTITY(1, 1),
        TrainID INT NOT NULL,
        DepartureLocation NVARCHAR(64) NOT NULL,
        ArrivalLocation NVARCHAR(64) NOT NULL,
        DepartureTime DATETIMEOFFSET NOT NULL,
        ArrivalTime DATETIMEOFFSET NULL, --Nullable so that we can plug it in later
        Distance INT NOT NULL,
        CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
        UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),

        CONSTRAINT [PK_Trains.Route.RouteID] PRIMARY KEY CLUSTERED
        (
            RouteID ASC
        ),

        CONSTRAINT FK_Trains_Route_Trains_Train FOREIGN KEY(TrainID)
        REFERENCES Trains.Train(TrainID)
    );
END

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
    (
        SELECT *
        FROM sys.key_constraints kc
        WHERE kc.parent_object_id = OBJECT_ID(N'Trains.Route')
            AND kc.[name] = N'UK_Trains_Route_DepartureLocation_ArrivalLocation_DepartureTime'
    )
BEGIN
    ALTER TABLE Trains.[Route]
    ADD CONSTRAINT [UK_Trains_Route_DepartureLocation_ArrivalLocation_DepartureTime] UNIQUE NONCLUSTERED
    (
        DepartureLocation,
        ArrivalLocation,
        DepartureTime
    )
END;

/****************************
 * Foreign Keys Constraints
 ****************************/

IF NOT EXISTS
    (
        SELECT *
        FROM sys.foreign_keys fk
        WHERE fk.parent_object_id = OBJECT_ID(N'Trains.Route')
            AND fk.referenced_object_id = OBJECT_ID(N'Trains.Train')
            AND fk.[name] = N'FK_Trains_Route_Trains_Train'
    )
BEGIN
    ALTER TABLE Train.[Route]
    ADD CONSTRAINT [FK_Trains_Route_Trains_Train] FOREIGN KEY
    (
        TrainID
    )
    REFERENCES Trains.Train
    (
        TrainID
    );
END;