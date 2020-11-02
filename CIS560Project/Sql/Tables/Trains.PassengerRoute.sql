IF OBJECT_ID(N'Trains.PassengerRoute') IS NULL
BEGIN
    CREATE TABLE Trains.PassengerRoute
    (
        PassengerRouteID INT NOT NULL IDENTITY(1, 1),
        PassengerID INT NOT NULL,
        RouteID INT NOT NULL,
        CarID INT NOT NULL,
        TicketPrice INT NOT NULL,
        CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
        UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),

        CONSTRAINT [PK_Trains.PassengerRoute.PassengerRouteID] PRIMARY KEY CLUSTERED
        (
            PassengerRouteID ASC
        ),

        CONSTRAINT FK_Trains_PassengerRoute_Trains_Passenger FOREIGN KEY(PassengerID)
        REFERENCES Trains.Passenger(PassengerID),
        
        CONSTRAINT FK_Trains_PassengerRoute_Trains_Route FOREIGN KEY(RouteID)
        REFERENCES Trains.[Route](RouteID),

        CONSTRAINT FK_Trains_PassengerRoute_Trains_Car FOREIGN KEY(CarID)
        REFERENCES Trains.Car(CarID)
    );
END

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
    (
        SELECT *
        FROM sys.key_constraints kc
        WHERE kc.parent_object_id = OBJECT_ID(N'Trains.PassengerRoute')
            AND kc.[name] = N'UK_Trains_PassengerRoute_PassengerID_RouteID'
    )
BEGIN
    ALTER TABLE Trains.PassengerRoute
    ADD CONSTRAINT [UK_Trains_PassengerRoute_PassengerID_RouteID] UNIQUE NONCLUSTERED
    (
        PassengerID,
        RouteID
    )
END;

/****************************
 * Foreign Keys Constraints
 ****************************/

IF NOT EXISTS
    (
        SELECT *
        FROM sys.foreign_keys fk
        WHERE fk.parent_object_id = OBJECT_ID(N'Trains.PassengerRoute')
            AND fk.referenced_object_id = OBJECT_ID(N'Trains.Passenger')
            AND fk.[name] = N'FK_Trains_PassengerRoute_Trains_Passenger'
    )
BEGIN
    ALTER TABLE Train.PassengerRoute
    ADD CONSTRAINT [FK_Trains_PassengerRoute_Trains_Passenger] FOREIGN KEY
    (
        PassengerID
    )
    REFERENCES Trains.Passenger
    (
        PassengerID
    );
END;

IF NOT EXISTS
    (
        SELECT *
        FROM sys.foreign_keys fk
        WHERE fk.parent_object_id = OBJECT_ID(N'Trains.PassengerRoute')
            AND fk.referenced_object_id = OBJECT_ID(N'Trains.Route')
            AND fk.[name] = N'FK_Trains_PassengerRoute_Trains_Route'
    )
BEGIN
    ALTER TABLE Train.PassengerRoute
    ADD CONSTRAINT [FK_Trains_PassengerRoute_Trains_Route] FOREIGN KEY
    (
        RouteID
    )
    REFERENCES Trains.[Route]
    (
        RouteID
    );
END;

IF NOT EXISTS
    (
        SELECT *
        FROM sys.foreign_keys fk
        WHERE fk.parent_object_id = OBJECT_ID(N'Trains.PassengerRoute')
            AND fk.referenced_object_id = OBJECT_ID(N'Trains.Car')
            AND fk.[name] = N'FK_Trains_PassengerRoute_Trains_Car'
    )
BEGIN
    ALTER TABLE Train.PassengerRoute
    ADD CONSTRAINT [FK_Trains_PassengerRoute_Trains_Car] FOREIGN KEY
    (
        CarID
    )
    REFERENCES Trains.Car
    (
        CarID
    );
END;
