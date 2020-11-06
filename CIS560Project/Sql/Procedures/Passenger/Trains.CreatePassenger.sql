CREATE OR ALTER PROCEDURE Trains.CreatePassenger
	@FirstName NVARCHAR(32),
	@LastName NVARCHAR(32),
	@Email NVARCHAR(128),
	@PassengerID INT OUTPUT
AS

INSERT Trains.Passenger(FirstName, LastName, Email)
VALUES(@FirstName, @LastName, @Email);

SET @PassengerID = SCOPE_IDENTITY();
GO
