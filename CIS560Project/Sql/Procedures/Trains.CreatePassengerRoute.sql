CREATE OR ALTER PROCEDURE Trains.CreateCar
	@TrainID INT,
	@CarTypeID  INT,
	@TicketPrice INT,
	@CarID INT OUTPUT
AS

INSERT TrainsCar(TrainID, CarTypeID, TicketPrice)
VALUES(@TrainID, @CarTypeID, @TicketPrice);

SET @CarID = SCOPE_IDENTITY();
GO