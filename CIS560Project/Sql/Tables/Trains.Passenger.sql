IF OBJECT_ID(N'Trains.Passenger') IS NULL
BEGIN
    CREATE TABLE Person.Person
    (
        PassengerID INT NOT NULL IDENTITY(1, 1),
        FirstName NVARCHAR(32) NOT NULL,
        LastName NVARCHAR(32) NOT NULL,
        Email NVARCHAR(128) NOT NULL,
        CreatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),
        UpdatedOn DATETIMEOFFSET NOT NULL DEFAULT(SYSDATETIMEOFFSET()),


        CONSTRAINT FK_Trains_Passenger_Trains_PassengerRoute FOREIGN KEY(PassengerRouteID)
        REFERENCES Trains.PassengerRoute(PassengerRouteID)
    );
END;

/****************************
 * Unique Constraints
 ****************************/

IF NOT EXISTS
    (
        SELECT *
        FROM sys.key_constraints kc
        WHERE kc.parent_object_id = OBJECT_ID(N'Trains.Passenger')
            AND kc.[name] = N'UK_Trains_Passenger_Email'
    )
BEGIN
    ALTER TABLE Trains.Passenger
    ADD CONSTRAINT [UK_Trains_Passenger_Email] UNIQUE NONCLUSTERED
    (
        Email
    )
END;

 /****************************
 * Foreign Keys Constraints
 ****************************/

