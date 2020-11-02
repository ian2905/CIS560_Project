CREATE OR ALTER PROCEDURE Trains.CreateRoute
	@TrainID INT,
	@DepartureLocation NVARCHAR(64),
	@ArrivalLocation NVARCHAR(64),
	@DepartureTime DATETIMEOFFSET,
	@Distance INT,
	@RouteID INT OUTPUT
AS

INSERT Trains.[Route](TrainID, DepartureLocation, ArrivalLocation, DepartureTime, Distance)
VALUES(@TrainID, @DepartureLocation, @ArrivalLocation, @DepartureTime, @Distance);

SET @RouteID = SCOPE_IDENTITY();
GO
